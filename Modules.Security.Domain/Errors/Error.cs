namespace Modules.Security.Domain.Errors;

public sealed record Error(string code, string? description = null)
{
    public static readonly Error None = new(string.Empty);
}
