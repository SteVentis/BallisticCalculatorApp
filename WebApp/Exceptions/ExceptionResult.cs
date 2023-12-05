namespace WebApp.Exceptions;

public class ExceptionResult
{
    public List<string> Messages { get; set; } = new();
    public string Source { get; set; } = null!;
    public string Exception { get; set; } = null!;
    public string ErrorId { get; set; } = null!;
    public string SupportMessage { get; set; } = null!;
    public int StatusCode { get; set; }
}
