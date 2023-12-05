using Modules.Security.Domain.Models;

namespace Modules.Security.Domain.Repositories.Interfaces;

public interface IRefreshTokenRepository
{
    Task AddRefreshTokenAsync(RefreshToken refreshToken);
    
    Task<RefreshToken> GetStoredRefreshTokenAsync(string refreshToken);

}
