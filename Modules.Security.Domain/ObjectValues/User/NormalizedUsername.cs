namespace Modules.Security.Domain.ObjectValues.User;

public record NormalizedUsername
{
    public NormalizedUsername(string value)
    {
        Value = value.ToUpper();
    }
    public string Value { get; private set; }

}
