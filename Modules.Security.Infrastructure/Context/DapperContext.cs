using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Modules.Security.Infrastructure.Context;

public sealed class DapperContext : IDbContext
{
    public string GetConnectionString()
    { 
        var relativePath = "appsettings.json";
        var currentDirectory = Path.GetDirectoryName(relativePath);
        var filePath = Path.Combine(currentDirectory, relativePath);

        IConfiguration myConfig = new ConfigurationBuilder()
        .SetBasePath(currentDirectory)
        .AddJsonFile(relativePath)
        .Build();

        return myConfig.GetConnectionString("Connection")!;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = GetConnectionString();

        return new SqlConnection(connectionString);
    }
    
    
}

