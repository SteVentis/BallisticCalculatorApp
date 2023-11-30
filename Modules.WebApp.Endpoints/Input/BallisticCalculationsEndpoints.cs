using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Modules.BallisticCalculations.Core.Abstractions;
using Modules.BallisticCalculations.Core.Models;

namespace Modules.WebApp.Endpoints.Input;

public static partial class BallisticCalculationsEndpoints
{
    public static void AddBallisticCalculationsInputEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/ballistic/calculations/ballistic-card",(IBallisticCardService ballisticService, InputBallisticData InputBallisticData) =>
        {
            return ballisticService.GenerateBallisticCard(InputBallisticData);
        });
    }
}
