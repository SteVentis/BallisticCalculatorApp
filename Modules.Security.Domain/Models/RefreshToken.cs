using Modules.Security.Domain.ObjectValues.RefreshToken;
using Modules.Security.Domain.ObjectValues.User;
using System.ComponentModel.DataAnnotations;

namespace Modules.Security.Domain.Models;

public class RefreshToken
{
    public long Id { get; set; }
    public Token Token { get; set; } = null!;
    public string JwtId { get; set; } = null!;
    public bool IsRevoked { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateExpire { get; set; }
    public UserId UserId { get; set; } = null!;

}
