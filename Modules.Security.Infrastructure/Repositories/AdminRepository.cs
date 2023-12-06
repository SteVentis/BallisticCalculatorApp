using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Context;

namespace Modules.Security.Infrastructure.Repositories;

internal sealed class AdminRepository : RepositoryBase, IAdminRepository
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public AdminRepository(IdentityAppDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : base(dbContext, userManager)
    {
        _roleManager = roleManager;
    }

    public async Task<List<IdentityRole>> GetRolesAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task AddRoleAsync(string roleName)
    {
        if (!_roleManager.RoleExistsAsync(roleName).Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleName;
            await _roleManager.CreateAsync(role);
        }

    }
}
