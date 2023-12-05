using Modules.Security.Application.Abstractions;
using Modules.Security.Application.Dtos;
using Modules.Security.Domain.Shared;
using Modules.Security.Domain.Repositories.Interfaces;
using AutoMapper;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.ObjectValues.User;

namespace Modules.Security.Application.Services;

internal sealed class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepo;
    private readonly IPasswordManager _passwordManager;
    private readonly IJwtProvider _jwtProvider;
    public AuthService(IAuthRepository authRepo, IPasswordManager passwordManager, IJwtProvider jwtProvider)
    {
        _authRepo = authRepo;
        _passwordManager = passwordManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<TResult<TokenResponse>> Login(UserLoginForm userLogin)
    {
        var user = await _authRepo.FindExistedUserByEmailOrUsernameAsync(userLogin.EmailOrUsername);

        if (user is null)
        {
            // Error

            return null!;
        }
        var hashTheGivenPassword = _passwordManager.Hash(userLogin.Password, out byte[] saltedPassword);

        var isPasswordValid = _passwordManager.Verify(userLogin.Password, hashTheGivenPassword, saltedPassword);

        if (!isPasswordValid)
        {
            // Error

            return null!;
        }

        TokenResponse tokenResponse = await _jwtProvider.GenerateJwtTokenAsync(user, null!);

        return TResult<TokenResponse>.Success(tokenResponse);
    }

    public async Task<TResult<TokenResponse>> RefreshToken(TokenRequest tokenRequest)
    {
        var tokenResponse = await _jwtProvider.VerifyAndGenerateTokenAsync(tokenRequest);

        return TResult<TokenResponse>.Success(tokenResponse);
    }

    public async Task<Result> Register(UserRegistrationForm user)
    {
        var checkIfUserExists = await _authRepo.FindExistedUserByEmailOrUsernameAsync(user.Email);

        if (checkIfUserExists is not null) 
        {
            // Error

            return null!;
        }
        var passwordHash = _passwordManager.Hash(user.Password, out var saltedPassword);

        // Email confirmation implementation

        bool emailConfirmed = true;

        var userToBeAdded = User.Create(
            new Username(user.Username), 
            new EmailAddress(user.Email), 
            emailConfirmed, new PasswordHash(passwordHash), 
            new PasswordSalt(saltedPassword));

        var result = await _authRepo.CreateUserAsync(userToBeAdded);

        // Check result with statement

        return Result.Success();
    }
}
