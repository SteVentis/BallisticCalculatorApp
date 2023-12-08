namespace Modules.Security.Application.AuthService;

public sealed record EmailToken
{
    public string EmailAddress { get; init; } = null!;
    public string Token { get; init; } = null!;
}