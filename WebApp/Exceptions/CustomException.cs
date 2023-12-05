using System.Net;

namespace WebApp.Exceptions;

public class CustomException : Exception
{
    public List<string> ErrorMessages { get; }
    public HttpStatusCode StatusCode { get; }

    public CustomException(string message, List<string> errors = default!,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base()
    {
        ErrorMessages = errors;
        StatusCode = statusCode;
    }
}
