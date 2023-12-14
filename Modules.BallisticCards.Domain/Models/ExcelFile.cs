namespace Modules.BallisticCards.Domain.Models;

public class ExcelFile
{
    public byte[] Content { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileName { get; set; } = null!;
}
