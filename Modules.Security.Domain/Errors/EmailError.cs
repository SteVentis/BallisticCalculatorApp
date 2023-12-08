namespace Modules.Security.Domain.Errors;

public static class EmailError
{
    public readonly static Error EmailsMismatch = new("Email address mismatch");
}
