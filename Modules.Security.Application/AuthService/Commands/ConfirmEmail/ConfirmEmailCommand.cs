using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.AuthService.Commands.ConfirmEmail;

public sealed record ConfirmEmailCommand(EmailToken EmailToken) : ICommand<TokenResponse>
{
}
