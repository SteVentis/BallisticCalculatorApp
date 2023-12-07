namespace Modules.Security.Application.AuthService;

public sealed record TokenResponse
{
    public string Token { get; set; } = null!;
    public string? RefreshToken { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
}
