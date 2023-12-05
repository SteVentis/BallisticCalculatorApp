using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;

namespace Modules.Security.Infrastructure.Repositories;

internal sealed class AdminRepository : IAdminRepository
{
    public async Task<List<Role>> GetRolesAsync()
    {
        return new List<Role>();
    }

    public async Task AddRoleAsync(Role role)
    {

    }
}
