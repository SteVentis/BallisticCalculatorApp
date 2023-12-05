﻿using System.ComponentModel.DataAnnotations;

namespace Modules.Security.Application.Dtos;

public record UserLoginForm
{
    [Required]
    public string EmailOrUsername { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
