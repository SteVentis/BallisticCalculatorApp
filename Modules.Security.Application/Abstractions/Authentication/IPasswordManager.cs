namespace Modules.Security.Application.Abstractions.Authentication;

public interface IPasswordManager
{
    string Hash(string password, out byte[] salt);
    bool Verify(string password, string hash, byte[] salt);
}
