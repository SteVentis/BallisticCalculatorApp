using BallisticCalculator;
using Modules.BallisticCalculations.Services.Models;

namespace Modules.BallisticCalculations.AbstraInterfaces;

public interface IBallisticCardService
{
    Task<List<TrajectoryPoint>> GenerateBallisticCard(InputBallisticData data);
}
