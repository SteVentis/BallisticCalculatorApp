namespace Modules.Security.Domain.ObjectValues.User;

public record EmailAddress
{
    
    public string Value { get; set; }

    public EmailAddress(string value)
    {
        Value = value;
    }

    public static EmailAddress Create(string value)
    {
        return new EmailAddress(value);
    }
}