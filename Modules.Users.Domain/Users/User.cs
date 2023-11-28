using Modules.Users.Domain.Abstractions;

namespace Modules.Users.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, FirstName firstName) : base(id)
    {
        FirstName = firstName;
    }

    public FirstName FirstName { get; private set; }

    public static User Create(FirstName firstName)
    {
        var user = new User(Guid.NewGuid(), firstName);

        user.Raise(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}
