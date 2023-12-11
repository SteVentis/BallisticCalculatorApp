using Modules.BallisticCards.Application.Abstractions;
using Modules.BallisticCards.Domain.Dtos;

namespace Modules.BallisticCards.Infrastructure.Services;

internal sealed class CacheMemoryService : ICacheMemoryService
{
    public Task<BallisticCardDto> GetBallsiticCardFromMemory(string id)
    {
        throw new NotImplementedException();
    }

    public Task InsertBallisticCardInMemory(BallisticCardDto ballisticCard)
    {
        throw new NotImplementedException();
    }
}
