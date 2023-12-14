using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.BallisticCards.Application.Abstractions;
using Modules.BallisticCards.Domain.Dtos;

namespace Modules.BallisticCards.Endpoints;

public static class BallisticCardEndpoints
{
    public static void AddBallisticCardEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("Insert/ballistic-card", (BallisticCardDto BallisticCardDto, IBallisticCardService ballisticCardService)=>
        {
            ballisticCardService.InsertBallisticCard(BallisticCardDto);

            return Results.Ok();
        });

        app.MapGet("get/ballistic-card/{id}", (long id, IBallisticCardService ballisticCardService)=>
        {
            var ballisticCard = ballisticCardService.GetBallisticCardById(id);

            return Results.Ok(ballisticCard);
        });

        app.MapGet("get/ballistic-card/user/{id}", (string id,IBallisticCardService ballisticCardService)=>
        {
            var ballisticCards = ballisticCardService.GetUsersAllBallisticCards(id);

            return Results.Ok(ballisticCards);
        });

        app.MapGet("delete/ballistic-card/{id}", (long id, IBallisticCardService ballisticCardService)=>
        {
            ballisticCardService.DeleteBallisticCard(id);

            return Results.Ok();
        });

        app.MapGet("export/ballistic-card/{id}", (long id, IBallisticCardService ballisticCardService)=>
        {
            var excelFile = ballisticCardService.ExportBallisticCardToExcel(id);

            return Results.File(excelFile.Content, excelFile.ContentType, excelFile.FileName);
        });
    }
}
