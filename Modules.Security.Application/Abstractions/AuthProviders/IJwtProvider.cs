using Modules.Security.Application.AuthService;
using Modules.Security.Domain.Models;

namespace Modules.Security.Application.Abstractions.AuthProviders;

public interface IJwtProvider
{
    Task<TokenResponse> VerifyAndGenerateTokenAsync(TokenRequest tokenRequest);
    Task<TokenResponse> GenerateJwtTokenAsync(User user, RefreshToken refreshToken);
}
