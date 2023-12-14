using BallisticCalculator;

namespace Modules.BallisticCalculations.Core.Models;

public class BallisticCard
{
    public string RifleName { get; set; } = null!;
    public double BulletWeigth { get; set; }
    public double BulletDiameter { get; set; }
    public double ZeroDistance { get; set; }
    public DateTime DateCreated { get; set; }

    public List<TrajectoryValues> TrajectoryValues { get; set; } = null!;



}
