namespace Modules.Security.Domain.ObjectValues.RefreshToken;

public record Token
{
    public Token(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public static Token Create()
    {
        var generateToken = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString();

        return new Token(generateToken);
    }
}
