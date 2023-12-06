using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Context;

namespace Modules.Security.Infrastructure.Repositories;

internal sealed class RefreshTokenRepository : RepositoryBase, IRefreshTokenRepository
{
    public RefreshTokenRepository(IdentityAppDbContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
    {
    }

    public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _dbContext.RefreshTokens.AddAsync(refreshToken);
        _dbContext.Entry(refreshToken).State = EntityState.Added;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<RefreshToken> GetStoredRefreshTokenAsync(string refreshToken)
    {
        var existedRefreshToken = await _dbContext!.RefreshTokens!.FirstOrDefaultAsync<RefreshToken>(x => x.Token == refreshToken);

        return existedRefreshToken!;
    }
}
