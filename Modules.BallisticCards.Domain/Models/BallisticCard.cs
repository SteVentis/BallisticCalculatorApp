namespace Modules.BallisticCards.Domain.Models;

public sealed class BallisticCard
{
    public long Id { get; set; }
    public string RifleName { get; set; } = null!;
    public string TrajectoryValuesJson { get; set; } = null!;
    public string UserId { get; set; } = null!;
}
