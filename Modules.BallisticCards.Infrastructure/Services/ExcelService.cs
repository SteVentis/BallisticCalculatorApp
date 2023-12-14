
using Modules.BallisticCards.Application.Abstractions;
using Modules.BallisticCards.Domain.Dtos;
using Modules.BallisticCards.Domain.Models;
using OfficeOpenXml;

namespace Modules.BallisticCards.Infrastructure.Services;

internal sealed class ExcelService : IExcelService
{
    public ExcelFile ExportBallisticCardToExcel(BallisticCardDto ballisticCard)
    {
        //License
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var package = new ExcelPackage())
        {
            // Work Sheet
            var workSheet =  package.Workbook.Worksheets.Add($"{ballisticCard.RifleName} Ballistic Card");

            // Headers
            workSheet.Cells[1, 1].Value = "Rifle Name : ";
            workSheet.Cells[2, 1].Value = "Distance";
            workSheet.Cells[2, 2].Value = "Elevation";
            workSheet.Cells[2, 3].Value = "Windage";
            workSheet.Cells[2, 4].Value = "ToF";

            workSheet.Cells[1, 2].Value = ballisticCard.RifleName;

            foreach (var trajectoryPoint in ballisticCard.TrajectoryValues)
            {
                workSheet.Cells[3, 1].Value = trajectoryPoint.Distance;
                workSheet.Cells[3, 2].Value = trajectoryPoint.Elevation;
                workSheet.Cells[3, 3].Value = trajectoryPoint.Windage;
                workSheet.Cells[3, 4].Value = trajectoryPoint.ToF;
            }

            var stream = new MemoryStream();

            package.SaveAs(stream);

            stream.Seek(0, SeekOrigin.Begin);

            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var filename = $"Ballistic_Card_Of_{ballisticCard.RifleName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";

            return new ExcelFile
            {
                Content = stream.ToArray(),
                ContentType = contentType,
                FileName = filename
            };
        }
    }
}
