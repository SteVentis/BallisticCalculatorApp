using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Application.Dtos;

namespace Modules.Security.Application.AuthService.Commands.Register;

public sealed record RegisterCommand(UserRegistrationForm UserRegistration) : ICommand
{
}
