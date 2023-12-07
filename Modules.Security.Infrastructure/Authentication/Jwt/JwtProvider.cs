using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modules.Security.Application.Abstractions.AuthProviders;
using Modules.Security.Application.AuthService;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modules.Security.Infrastructure.Authentication.Jwt;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly IRefreshTokenRepository _tokenRepo;
    private readonly IUserRepository _userRepo;
    private readonly JwtSettings _jwtSettings;
    private readonly UserManager<User> _userManager;
    public JwtProvider(
        IRefreshTokenRepository authRepo,
        IOptions<JwtSettings> jwtSettings,
        IUserRepository userRepo,
        UserManager<User> userManager)
    {
        _tokenRepo = authRepo;
        _jwtSettings = jwtSettings.Value;
        _userRepo = userRepo;
        _userManager = userManager;
    }

    public async Task<TokenResponse> GenerateJwtTokenAsync(User user, RefreshToken refreshToken)
    {
        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var userRoles = await _userManager.GetRolesAsync(user);

        foreach (var role in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var authSighninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(2),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSighninKey, SecurityAlgorithms.HmacSha256));

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        if (refreshToken != null)
        {
            var refreshTokenResponse = new TokenResponse();
            refreshTokenResponse.Token = jwtToken;
            refreshTokenResponse.RefreshToken = refreshToken.Token;
            refreshTokenResponse.ExpiresAt = token.ValidTo;

            return refreshTokenResponse;
        }

        RefreshToken newRefreshToken = new RefreshToken();
        newRefreshToken.JwtId = token.Id;
        newRefreshToken.IsRevoked = false;
        newRefreshToken.UserId = user.Id;
        newRefreshToken.DateAdded = DateTime.UtcNow;
        newRefreshToken.DateExpire = DateTime.UtcNow.AddMonths(6);
        newRefreshToken.Token = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString();

        await _tokenRepo.AddRefreshTokenAsync(newRefreshToken);

        var tokenResponse = new TokenResponse();
        tokenResponse.Token = jwtToken;
        tokenResponse.RefreshToken = newRefreshToken.Token;
        tokenResponse.ExpiresAt = token.ValidTo;

        return tokenResponse;


    }

    public async Task<TokenResponse> VerifyAndGenerateTokenAsync(TokenRequest tokenRequest)
    {
        var jwtHandler = new JwtSecurityTokenHandler();

        RefreshToken storedRefreshToken = await _tokenRepo.GetStoredRefreshTokenAsync(tokenRequest.RefreshToken);

        User user = await _userRepo.FindUserByIdAsync(storedRefreshToken.UserId);

        try
        {
            TokenValidationParameters parameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))

            };

            jwtHandler.ValidateToken(tokenRequest.Token, parameters, out var validatedToken);

            return await GenerateJwtTokenAsync(user, storedRefreshToken);
        }
        catch (SecurityTokenExpiredException)
        {
            if (storedRefreshToken.DateExpire >= DateTime.Now)
            {
                return await GenerateJwtTokenAsync(user, storedRefreshToken);
            }
            else
            {
                return await GenerateJwtTokenAsync(user, null!);
            }

        }
    }
}
