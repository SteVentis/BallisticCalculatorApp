using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Modules.BallisticCards.Infrastructure.Context;

public class DapperContext : IDbContext
{
    public IDbConnection CreateConnection()
    {
        var connectionString = GetConnectionStringFromJsonFile();

        return new SqlConnection(connectionString);
    } 
        
    
    public static string GetConnectionStringFromJsonFile()
    {
        IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

        return config.GetConnectionString("Connection")!;
    }
}
