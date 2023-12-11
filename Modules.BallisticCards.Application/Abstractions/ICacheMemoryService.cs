using Modules.BallisticCards.Domain.Dtos;
using Modules.BallisticCards.Domain.Models;

namespace Modules.BallisticCards.Application.Abstractions;

public interface ICacheMemoryService
{
    Task<BallisticCardDto> GetBallsiticCardFromMemory(string id);
    Task InsertBallisticCardInMemory(BallisticCardDto ballisticCard);
}
