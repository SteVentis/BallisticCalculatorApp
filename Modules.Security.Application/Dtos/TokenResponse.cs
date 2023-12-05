﻿namespace Modules.Security.Application.Dtos;

public class TokenResponse
{
    public string Token { get; set; } = null!;
    public string? RefreshToken { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
}
