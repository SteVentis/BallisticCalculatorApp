using Modules.BallisticCards.Domain.Dtos;
using Modules.BallisticCards.Domain.Models;

namespace Modules.BallisticCards.Application.Abstractions;

public interface IBallisticCardService
{
    Task InsertBallisticCard(BallisticCardDto ballisticCard);
    Task<List<BallisticCardDto>> GetUsersAllBallisticCards(string usersId);
    Task<BallisticCardDto> GetBallisticCardById(long id);
    Task DeleteBallisticCard(long id);
    ExcelFile ExportBallisticCardToExcel(long id);
}
