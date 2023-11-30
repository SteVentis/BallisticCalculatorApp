using Microsoft.Extensions.DependencyInjection;
using Modules.BallisticCalculations.Core.Abstractions;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;
using Modules.BallisticCalculations.Core.Builder;
using Modules.BallisticCalculations.Core.Builder.Director;
using Modules.BallisticCalculations.Core.Services;

namespace Modules.BallisticCalculations.Core.config;

public static class BallisticCalculationsConfiguration
{
    public static IServiceCollection AddBallisticCalculationsService(this IServiceCollection services)
    {

        services.AddScoped<IBallisticCardBuilder, BallisticCardBuilder>();
        services.AddScoped<IBallisticCardCalculator, BallisticCardCalculator>();
        services.AddScoped<IBallisticCardService, BallisticCardService>();

        return services;
    }
}
