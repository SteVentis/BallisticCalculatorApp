using Microsoft.Extensions.DependencyInjection;
using Modules.BallisticCards.Application.Abstractions;
using Modules.BallisticCards.Application.Mapping;
using Modules.BallisticCards.Application.Services;
using Modules.BallisticCards.Domain.Repositories.Interfaces;
using Modules.BallisticCards.Infrastructure.Repositories;

namespace Modules.BallisticCards.Infrastructure.config;

public static class BallisticCardModuleConfiguration
{
    public static IServiceCollection AddBallisticCardModuleServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BallisticCardProfile).Assembly);
        services.AddScoped<IBallisticCardRepository, BallisticCardRepository>();
        services.AddScoped<IBallisticCardService, BallisticCardService>();

        return services;

    }
}
