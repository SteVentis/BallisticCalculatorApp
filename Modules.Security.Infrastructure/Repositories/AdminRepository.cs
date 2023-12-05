using Dapper;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Context;
using System.Data;

namespace Modules.Security.Infrastructure.Repositories;

internal sealed class AdminRepository : IAdminRepository
{
    private readonly IDbContext _dbContext;
    public AdminRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        string query = "SELECT Name " +
                       "FROM Roles; ";

        using (var connection = _dbContext.CreateConnection())
        {
            var roles = await connection.QueryAsync<Role>(query);

            return roles;
        }
    }

    public async Task AddRoleAsync(Role role)
    {
        string query = "INSERT INTO Role " +
                       "VALUES ( " +
                       "@Name, @NormalizedName);";

        var parameters = new DynamicParameters();
        parameters.Add("Name", role.Name, DbType.String);
        parameters.Add("NormalizedName", role.NormalizedName, DbType.String);
        using (var connection = _dbContext.CreateConnection())
        {
            await connection.ExecuteAsync(query);
        }
    }
}
