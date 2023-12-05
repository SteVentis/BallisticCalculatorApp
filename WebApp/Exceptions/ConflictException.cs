using System.Net;

namespace WebApp.Exceptions
{
    public class ConflictException : CustomException
    {
        public ConflictException(string message, List<string> errors = null!, HttpStatusCode statusCode = HttpStatusCode.Conflict) : base(message, errors, statusCode)
        {
        }
    }
}
