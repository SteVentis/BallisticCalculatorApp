using Modules.Security.Domain.ObjectValues.User;

namespace Modules.Security.Domain.Models;

public class User
{

    public UserId Id { get; private set; } = null!;
    public Username? UserName { get; private set; }
    public NormalizedUsername? NormalizedUserName { get; private set; }
    public EmailAddress EmailAddress { get; private set; } = null!;
    public NormalizedEmailAddress NormalizedEmailAddress { get; private set; } = null!;
    public bool EmailConfirmed { get; private set; }
    public PasswordHash PasswordHash { get; private set; } = null!;
    public PasswordSalt PasswordSalt { get; private set; } = null!;

    public static User Create(
        Username? userName,
        EmailAddress emailAddress,
        bool emailConfirmed,
        PasswordHash passwordHash,
        PasswordSalt passwordSalt)
    {

        User user = new();
        user.Id = UserId.Create();
        
        if (string.IsNullOrEmpty(userName!.Value))
        {
            user.UserName = new Username(emailAddress.Value);
            user.NormalizedUserName = new NormalizedUsername(emailAddress.Value);
        }
        else
        {
            user.UserName = userName;
            user.NormalizedUserName = new NormalizedUsername(userName.Value);
        }
        user.EmailAddress = emailAddress;
        user.NormalizedEmailAddress = new NormalizedEmailAddress(emailAddress.Value);
        user.EmailConfirmed = emailConfirmed;
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;


        return user;

    }
}
