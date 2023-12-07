using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Modules.Security.Application.Abstractions.AuthProviders;
using Modules.Security.Domain.Models;

namespace Modules.Security.Infrastructure.Authentication.Email;

internal sealed class EmailProvider : IEmailProvider
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailSender _emailSender;
    public EmailProvider(UserManager<User> userManager, IEmailSender emailSender)
    {
        _userManager = userManager;
        _emailSender = emailSender;

    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
    {
        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task SendEmailMessageAsync(string username,string email, string subject, string content, IFormFileCollection attachments = null!)
    {
        var message = new EmailMessage(username, new string[] { email }, subject, content, attachments);

        await _emailSender.SendEmailAsync(message);
    }

    public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
    {
        var result = await _userManager.ConfirmEmailAsync(user, token);

        return result;
    }
}
