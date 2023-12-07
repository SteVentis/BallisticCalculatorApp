namespace Modules.Security.Application.AuthService;

public sealed record TokenRequest
{
    public required string Token { get; set; } = null!;

    public required string RefreshToken { get; set; } = null!;
}
