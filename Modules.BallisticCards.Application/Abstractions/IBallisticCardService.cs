using Modules.BallisticCards.Domain.Dtos;
namespace Modules.BallisticCards.Application.Abstractions;

public interface IBallisticCardService
{
    Task InsertBallisticCard(BallisticCardDto ballisticCard);
    Task<List<BallisticCardDto>> GetUsersAllBallisticCards(string UserId);
    Task DeleteBallisticCard(string id);
}
