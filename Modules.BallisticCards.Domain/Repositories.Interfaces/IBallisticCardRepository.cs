using Modules.BallisticCards.Domain.Models;

namespace Modules.BallisticCards.Domain.Repositories.Interfaces;

public interface IBallisticCardRepository
{
    Task InsertBallisticCard(BallisticCard ballisticCard);
    Task<List<BallisticCard>> GetUsersAllBallisticCards(string usersId);
    Task<BallisticCard> GetBallisticCardById(long id);
    Task DeleteBallisticCard(long id);

}
