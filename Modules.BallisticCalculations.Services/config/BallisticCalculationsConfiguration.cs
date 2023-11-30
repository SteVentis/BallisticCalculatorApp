using Microsoft.Extensions.DependencyInjection;
using Modules.BallisticCalculations.Core.Abstractions;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;
using Modules.BallisticCalculations.Services;
using Modules.BallisticCalculations.Services.Builder;
using Modules.BallisticCalculations.Services.Builder.Director;

namespace Modules.BallisticCalculations.Services.config;

public static class BallisticCalculationsConfiguration
{
    public static IServiceCollection AddBallisticCalculationsService(this IServiceCollection services)
    {

        services.AddScoped<ITrajectoryPointBuilder, TrajectoryPointBuilder>();
        services.AddScoped<ITrajectoryPointCalculator, TrajectoryPointCalculator>();
        services.AddScoped<IBallisticCardService, BallisticCardService>();
        return services;
    }
}
