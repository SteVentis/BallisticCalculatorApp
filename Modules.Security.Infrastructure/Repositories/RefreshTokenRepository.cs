using Dapper;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Context;
using System.Data;

namespace Modules.Security.Infrastructure.Repositories;

public sealed class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IDbContext _dbContext;

    public RefreshTokenRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        string query = "INSERT INTO RefreshTokens " +
                       "VALUES( " +
                       "@Token, " +
                       "@JwtId, " +
                       "@IsRevoked, " +
                       "@DateAdded, " +
                       "@DateExpire); ";

        var parameters = new DynamicParameters();
        parameters.Add("Token", refreshToken.Token.Value, DbType.String);
        parameters.Add("JwtId", refreshToken.JwtId, DbType.String);
        parameters.Add("IsRevoked", refreshToken.IsRevoked, DbType.Boolean);
        parameters.Add("DateAdded", refreshToken.DateAdded, DbType.DateTime2);
        parameters.Add("DateExpire", refreshToken.DateExpire, DbType.DateTime2);

        using (var connection = _dbContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    



    public async Task<RefreshToken> GetStoredRefreshTokenAsync(string refreshToken)
    {
        string query = "SELECT * " +
                       "FROM RefreshTokens " +
                       "WHERE Token = @refreshToken; ";

        using (var connection = _dbContext.CreateConnection())
        {
            RefreshToken? existedRefreshToken = await connection.QueryFirstOrDefaultAsync<RefreshToken>(query, new { refreshToken });

            return existedRefreshToken!;
        }
    }
}
