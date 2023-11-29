using BallisticCalculator;
using Modules.BallisticCalculations.Services.Models;

namespace Modules.BallisticCalculations.Core.Abstractions;

public interface IBallisticCardService
{
    Task<List<TrajectoryPoint>> GenerateBallisticCard(InputBallisticData data);
}
