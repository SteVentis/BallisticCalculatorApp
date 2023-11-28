using Modules.Users.Domain.Abstractions;

namespace Modules.Users.Domain.Users;

public sealed record UserCreatedDomainEvent(Guid userId) : IDomainEvent;
