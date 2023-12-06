using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Security.Domain.Models;

public class RefreshToken
{
    [Key]
    public long Id { get; set; }
    public string Token { get; set; } = null!;
    public string JwtId { get; set; } = null!;
    public bool IsRevoked { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateExpire { get; set; }

    // Navigation Properties
    public string UserId { get; set; } = null!;
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;




}
