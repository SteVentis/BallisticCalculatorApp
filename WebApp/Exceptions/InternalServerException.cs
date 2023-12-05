using System.Net;

namespace WebApp.Exceptions;

public class InternalServerException : CustomException
{
    public InternalServerException(string message, List<string> errors = null!, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) :
        base(message, errors, statusCode)
    {
    }
}

