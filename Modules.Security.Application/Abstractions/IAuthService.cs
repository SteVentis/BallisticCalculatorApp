using Modules.Security.Application.Dtos;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.Abstractions;

public interface IAuthService
{
    Task<TResult<TokenResponse>> Login(UserLoginForm userLogin);
    Task<Result> Register(UserRegistrationForm user);
    Task<TResult<TokenResponse>> RefreshToken(TokenRequest tokenRequest);
}
