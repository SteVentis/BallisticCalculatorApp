using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Modules.BallisticCalculations.Core.Abstractions;
using Modules.BallisticCalculations.Core.Models;

namespace Modules.BallisticCalculations.Endpoints;

public static partial class BallisticCalculationsEndpoints
{
    public static void AddBallisticCalculationsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/ballistic/calculations/ballistic-card",(IBallisticCardService ballisticService, InputBallisticData InputBallisticData) =>
        {
            return ballisticService.GenerateBallisticCard(InputBallisticData);
        });


    }
}
