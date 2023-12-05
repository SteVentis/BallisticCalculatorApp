using Modules.Security.Domain.Models;

namespace Modules.Security.Domain.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<bool> CheckPasswordAsync(User user, string password);
    Task AddRefreshTokenAsync(RefreshToken refreshToken);
    Task<User> CreateUserAsync(User user);
    Task<RefreshToken> GetStoredRefreshTokenAsync(string refreshToken);
    Task<User> FindExistedUserByEmailOrUsernameAsync(string emailOrUsername);
    Task<User> FindUserByIdAsync(Guid id);
}
