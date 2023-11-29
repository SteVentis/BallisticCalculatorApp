using Microsoft.Extensions.DependencyInjection;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;
using Modules.BallisticCalculations.Core.Services.Builder;
using Modules.BallisticCalculations.Core.Services.Builder.Director;

namespace Modules.BallisticCalculations.Core;

public static class BallisticCalculationsConfiguration
{
    public static IServiceCollection AddBallisticCalculationsService(this IServiceCollection services)
    {

        services.AddScoped<ITrajectoryPointBuilder, BallisticCardBuilder>();
        services.AddScoped<ITrajectoryPointCalculator, BallisticCardCalculator>();

        return services;
    }
}
