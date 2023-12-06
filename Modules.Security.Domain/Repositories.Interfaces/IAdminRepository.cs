using Microsoft.AspNetCore.Identity;
using Modules.Security.Domain.Models;

namespace Modules.Security.Domain.Repositories.Interfaces;

public interface IAdminRepository
{
    Task<List<IdentityRole>> GetRolesAsync();
    Task AddRoleAsync(string roleName);
}
