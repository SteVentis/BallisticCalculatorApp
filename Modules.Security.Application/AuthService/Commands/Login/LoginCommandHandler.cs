using Modules.Security.Application.Abstractions.AuthProviders;
using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Domain.Errors;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.AuthService.Commands.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, TokenResponse>
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IUserRepository userRepo, IJwtProvider jwtProvider)
    {
        _userRepo = userRepo;
        _jwtProvider = jwtProvider;
    }

    public async Task<TResult<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepo.FindExistedUserByEmailAsync(request.UserLoginForm.Email);

        TokenResponse response = null!;

        if (user is null)
        {
            return TResult<TokenResponse>.Failure(LoginError.EmailDoesNotExist, response);
        }

        var isPasswordValid = await _userRepo.CheckPasswordAsync(user, request.UserLoginForm.Password);

        if (!isPasswordValid)
        {
            return TResult<TokenResponse>.Failure(LoginError.InvalidPassword, response);
        }

        response = await _jwtProvider.GenerateJwtTokenAsync(user, null!);

        return TResult<TokenResponse>.Success(response);
    }
}
