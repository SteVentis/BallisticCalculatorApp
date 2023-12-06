using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Security.Application.Abstractions;
using Modules.Security.Application.Abstractions.Authentication;
using Modules.Security.Application.Services;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Authentication;
using Modules.Security.Infrastructure.Context;
using Modules.Security.Infrastructure.Repositories;
using Modules.Security.Application.Mapping;
namespace Modules.Security.Infrastructure.config;

public static class SecurityModuleConfiguration 
{

    public static IServiceCollection AddSecurityModuleServices(this IServiceCollection services)
    {
        var connectionString = GetConnectionStringFromJsonFile();
        services.AddDbContext<IdentityAppDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddAutoMapper(typeof(UserProfile).Assembly);
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
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
