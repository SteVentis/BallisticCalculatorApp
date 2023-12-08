using MailKit.Net.Smtp;
using MimeKit;
using Modules.Security.Domain.Models;

namespace Modules.Security.Infrastructure.Authentication.Email;

internal sealed class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSetings;

    public EmailSender(EmailSettings emailSettings)
    {
        _emailSetings = emailSettings;
    }

    public void SendEmail(EmailMessage message)
    {
        var emailMessage = CreateEmailMessage(message);

        Send(emailMessage);
    }

    public async Task SendEmailAsync(EmailMessage message)
    {
        var emailMessage = CreateEmailMessage(message);

        await SendAsync(emailMessage);
    }

    private MimeMessage CreateEmailMessage(EmailMessage message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailSetings.Username, _emailSetings.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;

        var bodybuilder = new BodyBuilder
        {
            HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content)
        };

        if (message.Attachments != null && message.Attachments.Any())
        {
            byte[] fileBytes;
            foreach (var attachment in message.Attachments)
            {
                using (var stream = new MemoryStream())
                {
                    attachment.CopyTo(stream);
                    fileBytes = stream.ToArray();
                }
                bodybuilder.Attachments.Add(attachment.FileName,fileBytes, ContentType.Parse(attachment.ContentType));
            }
        }

        emailMessage.Body = bodybuilder.ToMessageBody();

        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(_emailSetings.SmtpServer, _emailSetings.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailSetings.Username, _emailSetings.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception, or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
            }

        }
    }

    private async Task SendAsync(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync(_emailSetings.SmtpServer, _emailSetings.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailSetings.Username, _emailSetings.Password);

                await client.SendAsync(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception, or both.
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}
