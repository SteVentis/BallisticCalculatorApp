using Microsoft.Extensions.Options;
using Modules.Security.Infrastructure.Authentication;

namespace WebApp.AuthOptionSetup;

public class JwtSettingsSetup : IConfigureOptions<JwtSettings>
{
    private const string SectionName = "JwtSettings";

    private readonly IConfiguration _configuration;

    public JwtSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtSettings options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
