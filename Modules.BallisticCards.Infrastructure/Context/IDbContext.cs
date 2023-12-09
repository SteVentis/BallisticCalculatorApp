using System.Data;

namespace Modules.BallisticCards.Infrastructure.Context;

public interface IDbContext
{
    IDbConnection CreateConnection();
}
