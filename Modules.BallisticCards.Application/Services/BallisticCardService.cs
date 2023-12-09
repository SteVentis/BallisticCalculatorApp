using Modules.BallisticCards.Application.Abstractions;
using Modules.BallisticCards.Domain.Dtos;

namespace Modules.BallisticCards.Application.Services;

public sealed class BallisticCardService : IBallisticCardService
{
    public Task DeleteBallisticCard(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BallisticCardDto>> GetUsersAllBallisticCards(string UserId)
    {
        throw new NotImplementedException();
    }

    public Task InsertBallisticCard(BallisticCardDto ballisticCard)
    {
        throw new NotImplementedException();
    }
}
