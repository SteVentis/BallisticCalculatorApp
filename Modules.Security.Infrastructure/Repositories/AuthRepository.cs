using Microsoft.AspNetCore.Identity;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Context;

namespace Modules.Security.Infrastructure.Repositories;

public sealed class AuthRepository : IAuthRepository
{
    private readonly UserManager<User> _userManager;
    private readonly IDbContext _dbContext;

    public AuthRepository(UserManager<User> userManager, IDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        
        throw new NotImplementedException();
    }

    public Task<bool> CheckPasswordAsync(User user, string password)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindExistedUserByEmailOrUsernameAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindUserByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshToken> GetStoredRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }
}
