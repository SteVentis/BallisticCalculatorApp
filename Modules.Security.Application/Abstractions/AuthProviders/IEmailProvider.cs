using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Modules.Security.Domain.Models;

namespace Modules.Security.Application.Abstractions.AuthProviders;

public interface IEmailProvider
{
    Task<string> GenerateEmailConfirmationTokenAsync(User user);
    Task SendEmailMessageAsync(string username, string email, string subject, string content, IFormFileCollection attachments = null!);
    Task<IdentityResult> ConfirmEmailAsync(User user, string token);
}
