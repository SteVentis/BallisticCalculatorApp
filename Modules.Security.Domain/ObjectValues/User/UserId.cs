using System.Runtime.InteropServices;

namespace Modules.Security.Domain.ObjectValues.User;

public record UserId
{
    public Guid Value { get; private set; }
    public UserId(Guid value)
    {
        Value = value;
    }
    public static UserId Create()
    {
        UserId userId = new UserId(Guid.NewGuid());

        return userId;
    }
}
