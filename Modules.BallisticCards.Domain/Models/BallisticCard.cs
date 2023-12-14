namespace Modules.BallisticCards.Domain.Models;

public sealed class BallisticCard
{
    public long Id { get; set; }
    public string RifleName { get; set; } = null!;
    public double BulletWeigth { get; set; }
    public double BulletDiameter { get; set; }
    public double ZeroDistance { get; set; }
    public DateTime DateCreated { get; set; }
    public string TrajectoryValuesJson { get; set; } = null!;
    public string UserId { get; set; } = null!;
}
