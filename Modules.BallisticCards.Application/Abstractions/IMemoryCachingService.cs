using Modules.BallisticCards.Domain.Dtos;
using Modules.BallisticCards.Domain.Models;

namespace Modules.BallisticCards.Application.Abstractions;

public interface IMemoryCachingService
{
    BallisticCardDto GetBallisticCardFromMemory(long id);
    void InsertBallisticCardInMemory(BallisticCardDto ballisticCard);
    void DeleteBallisticCardInMemory(long id);
}
