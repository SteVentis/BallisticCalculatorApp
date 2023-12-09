using Modules.BallisticCards.Domain.Models;

namespace Modules.BallisticCards.Domain.Repositories.Interfaces;

public interface IBallisticCardRepository
{
    Task InsertBallisticCard(BallisticCard ballisticCard);
    Task<List<BallisticCard>> GetUsersAllBallisticCards(string usersId);
    Task DeleteBallisticCard(string id);

}
