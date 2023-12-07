using AutoMapper;
using Modules.Security.Application.Abstractions.AuthProviders;
using Modules.Security.Application.Abstractions.Messaging;
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

        if (user is null)
        {
            // Error

            return null!;
        }

        var isPasswordValid = await _userRepo.CheckPasswordAsync(user, request.UserLoginForm.Password);

        if (!isPasswordValid)
        {
            // Error

            return null!;
        }

        TokenResponse tokenResponse = await _jwtProvider.GenerateJwtTokenAsync(user, null!);

        return TResult<TokenResponse>.Success(tokenResponse);
    }
}
