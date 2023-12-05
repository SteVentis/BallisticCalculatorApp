namespace Modules.Security.Domain.ObjectValues.Role;

public class RoleId
{

    public Guid Value { get; private set; }

    public RoleId Create()
    {
        RoleId roleId = new();
        roleId.Value = Guid.NewGuid();

        return roleId;
    }
}