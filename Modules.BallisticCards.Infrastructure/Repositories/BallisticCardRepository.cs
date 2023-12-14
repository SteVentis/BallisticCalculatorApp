using Dapper;
using Modules.BallisticCards.Domain.Models;
using Modules.BallisticCards.Domain.Repositories.Interfaces;
using Modules.BallisticCards.Infrastructure.Context;
using System.Data;

namespace Modules.BallisticCards.Infrastructure.Repositories;

internal sealed class BallisticCardRepository : IBallisticCardRepository
{
    private readonly IDbContext _dbContext;

    public BallisticCardRepository(IDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public async Task DeleteBallisticCard(long id)
    {
        string query = "DELETE " +
                       "FROM BallisticCards " +
                       "WHERE Id = @id; ";

        using (var connection = _dbContext.CreateConnection()) 
        { 
            await connection.ExecuteAsync(query);
        }
    }

    public async Task<BallisticCard> GetBallisticCardById(long id)
    {
        string query = "SELECT * " +
                       "FROM BallisticCards " +
                       "WHERE Id = @id";

        using (var connection = _dbContext.CreateConnection())
        {
            BallisticCard? ballisticCard = await connection.QueryFirstOrDefaultAsync<BallisticCard>(query, new { Id = id });

            return ballisticCard!;
        }
    }

    public async  Task<List<BallisticCard>> GetUsersAllBallisticCards(string usersId)
    {
        string query = "SELECT * " +
                       "FROM BallisticCards " +
                       "WHERE UserId = @userId ";

        using(var connection = _dbContext.CreateConnection()) 
        {
            IEnumerable<BallisticCard> ballisticCards = await connection
                .QueryAsync<BallisticCard>(query, new { UserId = usersId });

            return ballisticCards.ToList();
        }
    }

    public async Task InsertBallisticCard(BallisticCard ballisticCard)
    {
        string query = @"INSERT INTO BallisticCards " +
                       "VALUES(Riflename, " +
                       "BulletWeight, " +
                       "BulletDiameter, " +
                       "ZeroDistance, " +
                       "DateCreated, " +
                       "TrajectoryValuesJson, " +
                       "UserId); ";
        
        var parameters = new DynamicParameters();
        parameters.Add("Riflename", ballisticCard.RifleName, DbType.String);
        parameters.Add("BulletWeight", ballisticCard.BulletWeigth, DbType.Double);
        parameters.Add("BulletDiameter", ballisticCard.BulletDiameter, DbType.Double);
        parameters.Add("ZeroDistance", ballisticCard.ZeroDistance, DbType.Double);
        parameters.Add("DateCreated", ballisticCard.DateCreated,DbType.DateTime2);
        parameters.Add("TrajectoryValuesJson", ballisticCard.TrajectoryValuesJson, DbType.String);
        parameters.Add("UserId", ballisticCard.UserId, DbType.String);

        using(var connection = _dbContext.CreateConnection()) 
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
