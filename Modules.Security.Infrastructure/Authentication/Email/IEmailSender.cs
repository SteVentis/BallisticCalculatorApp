namespace Modules.Security.Infrastructure.Authentication.Email;

internal interface IEmailSender
{
    void SendEmail(EmailMessage message);
    Task SendEmailAsync(EmailMessage message);
}
