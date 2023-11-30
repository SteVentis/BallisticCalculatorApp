using BallisticCalculator;
using Modules.BallisticCalculations.Core.Models;

namespace Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;

public interface IBallisticCardCalculator
{
    Task<BallisticCard> Generate(InputBallisticData inputBallisticData);
}
