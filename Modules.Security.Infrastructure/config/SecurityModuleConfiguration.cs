using Microsoft.Extensions.DependencyInjection;
using Modules.Security.Application.Abstractions.Authentication;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Authentication;
using Modules.Security.Infrastructure.Context;
using Modules.Security.Infrastructure.Repositories;

namespace Modules.Security.Infrastructure.config;

public static class SecurityModuleConfiguration 
{

    public static IServiceCollection AddSecurityModuleServices(this IServiceCollection services)
    {

        services.AddSingleton<IDbContext, DapperContext>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
