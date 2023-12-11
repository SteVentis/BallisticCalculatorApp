using Modules.BallisticCards.Domain.Dtos;
using OfficeOpenXml;

namespace Modules.BallisticCards.Application.Abstractions;

public interface IExcelService
{
    ExcelWorksheet ExportBallisticCardToExcel(BallisticCardDto ballisticCard);
}
