namespace Modules.Users.Domain.Users;

public sealed record FirstName
{
    public FirstName(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);

        Value = value;
    }

    public string Value { get; }


}
