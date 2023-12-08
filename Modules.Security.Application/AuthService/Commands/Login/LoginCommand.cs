using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Domain.Dtos;



namespace Modules.Security.Application.AuthService.Commands.Login;

public sealed record LoginCommand(UserLoginForm UserLoginForm) : ICommand<TokenResponse>
{
}
