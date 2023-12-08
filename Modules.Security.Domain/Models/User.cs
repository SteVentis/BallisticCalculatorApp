using Microsoft.AspNetCore.Identity;

namespace Modules.Security.Domain.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

}
    

