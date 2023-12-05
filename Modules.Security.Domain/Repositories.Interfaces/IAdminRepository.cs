using Modules.Security.Domain.Models;

namespace Modules.Security.Domain.Repositories.Interfaces;

public interface IAdminRepository
{
    Task<IEnumerable<Role>> GetRolesAsync();
    Task AddRoleAsync(Role role);
}
