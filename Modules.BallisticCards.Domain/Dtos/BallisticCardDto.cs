using Modules.BallisticCards.Domain.Models;

namespace Modules.BallisticCards.Domain.Dtos;

public class BallisticCardDto
{
    public string RifleName { get; set; } = null!;
    public List<TrajectoryValues> TrajectoryValues { get; set; } = null!;
}
