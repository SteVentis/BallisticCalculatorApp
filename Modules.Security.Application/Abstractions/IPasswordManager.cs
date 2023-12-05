namespace Modules.Security.Application.Abstractions;

public interface IPasswordManager
{
    string Hash(string password, out byte[] salt);
    bool Verify(string password, string hash, byte[] salt);
}
