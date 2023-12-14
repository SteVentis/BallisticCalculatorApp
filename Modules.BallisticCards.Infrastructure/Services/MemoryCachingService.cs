using Microsoft.Extensions.Caching.Memory;
using Modules.BallisticCards.Application.Abstractions;
using Modules.BallisticCards.Domain.Dtos;

namespace Modules.BallisticCards.Infrastructure.Services;

internal sealed class MemoryCachingService : IMemoryCachingService
{
    private readonly IMemoryCache _cache;
    public MemoryCachingService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public BallisticCardDto GetBallisticCardFromMemory(long id)
    {
        BallisticCardDto? ballisticCard = _cache.Get<BallisticCardDto>(id);

        return ballisticCard!;
    }

    public void InsertBallisticCardInMemory(BallisticCardDto ballisticCard)
    {
        _cache.Set(ballisticCard.Id, ballisticCard);

    }

    public void DeleteBallisticCardInMemory(long id)
    {
        _cache.Remove(id);
    }
}
