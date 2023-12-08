using Microsoft.AspNetCore.Identity;
using Modules.Security.Domain.Models;

namespace Modules.Security.Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> CheckPasswordAsync(User user, string password);
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<User> FindExistedUserByEmailAsync(string email);
    Task<User> FindUserByIdAsync(string id);
    Task AddUserToRole(User user);
}

