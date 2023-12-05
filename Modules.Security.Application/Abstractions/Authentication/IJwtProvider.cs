using Modules.Security.Application.Dtos;
using Modules.Security.Domain.Models;

namespace Modules.Security.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    Task<TokenResponse> VerifyAndGenerateTokenAsync(TokenRequest tokenRequest);
    Task<TokenResponse> GenerateJwtTokenAsync(User user, RefreshToken refreshToken);
}
