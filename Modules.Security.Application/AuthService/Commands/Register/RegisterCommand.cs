using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Domain.Dtos;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.AuthService.Commands.Register;

public sealed record RegisterCommand(UserRegistrationForm UserRegistration) : ICommand<TResult<EmailToken>>
{
}
