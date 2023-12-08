namespace Modules.BallisticCards.Domain.Models;

public sealed class BallisticCard
{
    public string Id { get; set; } = null!;
    public string RifleName { get; set; } = null!;
    public string TrajectoryValues { get; set; } = null!;
}
