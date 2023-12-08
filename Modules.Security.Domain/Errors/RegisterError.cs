namespace Modules.Security.Domain.Errors;

public static class RegisterError
{
    public readonly static Error UserExists = new("User cannot register because this email exists.");
    public readonly static Error CannotRegister = new("Problem to register user.");
    public readonly static Error CannotFindUser = new("Cannot find user with this email.");
}
