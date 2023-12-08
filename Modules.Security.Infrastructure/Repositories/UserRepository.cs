using Microsoft.AspNetCore.Identity;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Context;

namespace Modules.Security.Infrastructure.Repositories;

internal sealed class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(IdentityAppDbContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
    {
    }

    public async Task AddUserToRole(User user)
    {
        await _userManager.AddToRoleAsync(user, Role.User);
    }

    public async Task<bool> CheckPasswordAsync(User user, string password) =>
        await _userManager.CheckPasswordAsync(user, password);

    public async Task<IdentityResult> CreateUserAsync(User user, string password)
    {
        var registerResult = await _userManager.CreateAsync(user, password);

        return registerResult;

    }

    public async Task<User> FindExistedUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        return user!;
    }

    public async Task<User> FindUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        return user!;
    }
}

