using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Security.Infrastructure.Authentication.Email;

internal class EmailMessage
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
