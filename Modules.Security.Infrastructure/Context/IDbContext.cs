using System.Data;

namespace Modules.Security.Infrastructure.Context;

public interface IDbContext
{
    IDbConnection CreateConnection();
}
