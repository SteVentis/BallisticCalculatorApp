using Modules.Security.Domain.ObjectValues.Role;

namespace Modules.Security.Domain.Models;

public class Role 
{
    public RoleId Id { get; private set; }
    public string Name { get; private set; }
    public string NormalizedName { get; private set; }
}
