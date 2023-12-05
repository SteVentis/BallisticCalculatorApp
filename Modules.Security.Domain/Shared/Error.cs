﻿namespace Modules.Security.Domain.Shared;

public sealed record Error(string code, string? description = null)
{
    public static readonly Error None = new(string.Empty);
}
