namespace Modules.Security.Domain.Errors;

public static class LoginError
{
    public static readonly Error EmailDoesNotExist = new("The email address entered does not exist. Please double-check the email address for accuracy.");
    public static readonly Error InvalidPassword = new("The password that you entered is invalid.");
}
