using Dapper;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Context;
using System.Data;

namespace Modules.Security.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext dbConnection)
    {
        _dbContext = dbConnection;
    }

    public async Task<int> CreateUserAsync(User user)
    {
        string query = "INSERT INTO Users " +
                       "VALUES(" +
                       "@Id, " +
                       "@Username, " +
                       "@NormalizedUsername, " +
                       "@EmailAddress, " +
                       "@NormalizedEmailAddress, " +
                       "@EmailConfirmed, " +
                       "@PasswordHash, " +
                       "@PasswordSalt);";

        var parameters = new DynamicParameters();
        parameters.Add("Id", user.Id.Value, DbType.Guid);
        parameters.Add("Username", user.Username!.Value, DbType.String);
        parameters.Add("NormalizedUsername", user.NormalizedUsername, DbType.String);
        parameters.Add("EmailAddress", user.EmailAddress, DbType.String);
        parameters.Add("NormalizedEmailAddress", user.NormalizedEmailAddress, DbType.String);
        parameters.Add("EmailConfirmed", user.EmailConfirmed, DbType.Boolean);
        parameters.Add("PasswordHash", user.PasswordHash, DbType.String);
        parameters.Add("PasswordSalt", user.PasswordSalt, DbType.String);

        using (var connection = _dbContext.CreateConnection())
        {
            var result = await connection.ExecuteAsync(query, parameters);

            return result;
        }


    }


    public async Task<User> FindExistedUserByEmailOrUsernameAsync(string emailOrUsername)
    {
        string query = "SELECT * " +
                       "FROM Users " +
                       "WHERE EmailAddress = @EmailOrUsername OR Username = @EmailOrUsername; ";

        using (var connection = _dbContext.CreateConnection())
        {
            User? user = await connection.QuerySingleOrDefaultAsync<User>(query, new { emailOrUsername });

            return user!;
        }
    }

    public async Task<User> FindUserByIdAsync(Guid id)
    {
        string query = "SELECT * " +
                       "FROM Users " +
                       "WHERE Id = @id ";

        using (var connection = _dbContext.CreateConnection())
        {
            User? user = await connection.QuerySingleOrDefaultAsync<User>(query, new { id });

            return user!;
        }
    }
}
