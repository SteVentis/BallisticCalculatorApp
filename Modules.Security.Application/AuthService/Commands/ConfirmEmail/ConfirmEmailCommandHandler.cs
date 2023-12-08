using Modules.Security.Application.Abstractions.AuthProviders;
using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Domain.Errors;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.AuthService.Commands.ConfirmEmail;

internal sealed class ConfirmEmailCommandHandler : ICommandHandler<ConfirmEmailCommand, TokenResponse>
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtProvider _jwtProvider;
    private readonly IEmailProvider _emailProvider;
    public ConfirmEmailCommandHandler(
        IUserRepository userRepo, 
        IJwtProvider jwtProvider, 
        IEmailProvider emailProvider)
    {
        _userRepo = userRepo;
        _jwtProvider = jwtProvider;
        _emailProvider = emailProvider;
    }
    public async Task<TResult<TokenResponse>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        TokenResponse response = null!;

        var user = await _userRepo.FindExistedUserByEmailAsync(request.EmailToken.EmailAddress);
        if (user == null)
        {
            return TResult<TokenResponse>.Failure(RegisterError.CannotFindUser, response);
        }

        var result = await _emailProvider.ConfirmEmailAsync(user, request.EmailToken.Token); 

        if (!result.Succeeded)
        {
            return TResult<TokenResponse>.Failure(EmailError.EmailsMismatch, response);
        }

        TokenResponse tokenResponse = await _jwtProvider.GenerateJwtTokenAsync(user, null!);

        return TResult<TokenResponse>.Success(tokenResponse);
    }
}
