namespace Modules.Security.Domain.ObjectValues.User;

public record Username
{
    public Username(string value)
    {
        Value = value;
    }

    public string Value { get; init; }

    public static Username Create(string value)
    {
        return new Username(value);

    }
}
