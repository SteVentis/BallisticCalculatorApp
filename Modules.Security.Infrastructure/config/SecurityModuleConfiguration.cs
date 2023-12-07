using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Security.Application.Abstractions.AuthProviders;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Infrastructure.Context;
using Modules.Security.Infrastructure.Repositories;
using Modules.Security.Application.Mapping;
using Modules.Security.Infrastructure.Authentication.Jwt;
using Modules.Security.Infrastructure.Authentication.Email;
using Modules.Security.Application.MediatRconfig;

namespace Modules.Security.Infrastructure.config;

public static class SecurityModuleConfiguration 
{

    public static IServiceCollection AddSecurityModuleServices(this IServiceCollection services)
    {
        IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

        var connectionString = config.GetConnectionString("Connection")!;

        services.AddMediatRService();

        services.AddDbContext<IdentityAppDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped<EmailSettings>();
        services.AddScoped<IEmailProvider, EmailProvider>();
        services.AddAutoMapper(typeof(AppUserProfile).Assembly);
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    


}
