using System.Security.Cryptography;
using System.Text;

namespace Modules.Security.Domain.ObjectValues.User;

public record PasswordHash
{
    public PasswordHash(string value)
    {
        Value = value;
    }
    public string Value { get; private set; }

    
}
