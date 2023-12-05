using Modules.Security.Application.Abstractions.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace Modules.Security.Infrastructure.Authentication;

public class PasswordManager : IPasswordManager
{
    private const int keySize = 64;
    private const int iterations = 35000;
    private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;


    public string Hash(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(keySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            hashAlgorithm,
            keySize);

        return Convert.ToHexString(hash);
    }

    public bool Verify(string password, string hash, byte[] salt)
    {
        var hashCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

        return CryptographicOperations.FixedTimeEquals(hashCompare, Convert.FromHexString(hash));
    }
}
