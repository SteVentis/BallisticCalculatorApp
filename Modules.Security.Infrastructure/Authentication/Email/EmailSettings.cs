using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Security.Infrastructure.Authentication.Email
{
    public sealed class EmailSettings
    {
        public string From { get; init; } = null!;
        public string SmtpServer { get; init; } = null!;
        public int Port { get; init; }
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}
