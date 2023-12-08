using Modules.Security.Domain.Models;

namespace Modules.Security.Domain.Errors;

public static class RegisterError
{
    public static Error UserExists(User user) => new(
        $"User {user.FirstName + " " + user.LastName} cannot register because the email {user.Email} exists.");
    public static Error CannotFindUser(string email) => new($"Cannot find user with this {email} email.");
}
