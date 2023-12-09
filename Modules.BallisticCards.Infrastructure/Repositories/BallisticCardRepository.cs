using Dapper;
using Modules.BallisticCards.Domain.Models;
using Modules.BallisticCards.Domain.Repositories.Interfaces;
using Modules.BallisticCards.Infrastructure.Context;

namespace Modules.BallisticCards.Infrastructure.Repositories;

internal sealed class BallisticCardRepository : IBallisticCardRepository
{
    private readonly IDbContext _dbContext;

    public BallisticCardRepository(IDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public async Task DeleteBallisticCard(string id)
    {
        string query = "DELETE " +
                       "FROM BallisticCards " +
                       "WHERE Id = @id; ";

        using (var connection = _dbContext.CreateConnection()) 
        { 
            await connection.ExecuteAsync(query);
        }
    }

    public async  Task<List<BallisticCard>> GetUsersAllBallisticCards(string usersId)
    {
        string query = "SELECT * " +
                       "FROM BallisticCards " +
                       "WHERE UserId = @userId ";

        using(var connection = _dbContext.CreateConnection()) 
        {
            var ballisticCards = await connection
                .QueryAsync<BallisticCard>(query, new { UserId = usersId });

            return ballisticCards.ToList();
        }
    }

    public async Task InsertBallisticCard(BallisticCard ballisticCard)
    {
        string query = "INSERT INTO BallisticCards " +
                       "VALUES()";
        
        var parameters = new DynamicParameters();
        parameters.Add("");
        parameters.Add("");
        parameters.Add("");
        parameters.Add("");

        using(var connection = _dbContext.CreateConnection()) 
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
