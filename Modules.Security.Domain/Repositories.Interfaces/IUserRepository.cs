using Modules.Security.Domain.Models;

namespace Modules.Security.Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task<int> CreateUserAsync(User user);
    Task<User> FindExistedUserByEmailOrUsernameAsync(string emailOrUsername);
    Task<User> FindUserByIdAsync(Guid id);
}
