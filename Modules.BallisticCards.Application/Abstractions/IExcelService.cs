using Modules.BallisticCards.Domain.Dtos;
using Modules.BallisticCards.Domain.Models;
using OfficeOpenXml;

namespace Modules.BallisticCards.Application.Abstractions;

public interface IExcelService
{
    ExcelFile ExportBallisticCardToExcel(BallisticCardDto ballisticCard);
}
