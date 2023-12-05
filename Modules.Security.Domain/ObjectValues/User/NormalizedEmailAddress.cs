namespace Modules.Security.Domain.ObjectValues.User;

public record NormalizedEmailAddress
{
    public NormalizedEmailAddress(string value)
    {
        Value = value.ToUpper();
    }
    public string Value { get; private set; }
}
