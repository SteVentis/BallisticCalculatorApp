using Modules.Security.Application.Abstractions.Messaging;


namespace Modules.Security.Application.AuthService.Commands.RefreshToken;

public sealed record RefreshTokenCommand(TokenRequest TokenRequest) : ICommand<TokenResponse>
{
}
