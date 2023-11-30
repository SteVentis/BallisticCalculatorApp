using BallisticCalculator;
using Modules.BallisticCalculations.Core.Models;

namespace Modules.BallisticCalculations.Core.Abstractions;

public interface IBallisticCardService
{
    Task<BallisticCard> GenerateBallisticCard(InputBallisticData data);
}
