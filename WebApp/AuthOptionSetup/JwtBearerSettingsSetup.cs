using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modules.Security.Infrastructure.Authentication;
using System.Text;

namespace WebApp.AuthOptionSetup;

public class JwtBearerSettingsSetup : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtSettings _jwtSettings;

    public JwtBearerSettingsSetup(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
        };
    }
}
