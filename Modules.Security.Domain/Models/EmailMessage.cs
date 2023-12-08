using Microsoft.AspNetCore.Http;
using MimeKit;

namespace Modules.Security.Domain.Models;

public class EmailMessage
{
    public EmailMessage(string username, IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
    {
        To = new List<MailboxAddress>();

        To.AddRange(to.Select(x => new MailboxAddress(username,x)));

        Subject = subject;
        Content = content;
        Attachments = attachments;
    }
    public List<MailboxAddress> To {  get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public IFormFileCollection Attachments { get; set; }
}
