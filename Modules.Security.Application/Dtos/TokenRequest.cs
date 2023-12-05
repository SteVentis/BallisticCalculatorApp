namespace Modules.Security.Application.Dtos;

public class TokenRequest
{
    public required string Token { get; set; } = null!;

    public required string RefreshToken { get; set; } = null!;
}
