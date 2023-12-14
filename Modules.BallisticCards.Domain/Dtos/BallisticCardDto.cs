using Modules.BallisticCards.Domain.Models;

namespace Modules.BallisticCards.Domain.Dtos;

public class BallisticCardDto
{
    public long Id { get; set; }
    public string RifleName { get; set; } = null!;
    public double BulletWeigth { get; set; }
    public double BulletDiameter { get; set; }
    public double ZeroDistance { get; set; }
    public DateTime DateCreated { get; set; }
    public List<TrajectoryValues> TrajectoryValues { get; set; } = null!;
}
