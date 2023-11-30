using Modules.BallisticCalculations.Core.Abstractions;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;
using Modules.BallisticCalculations.Core.Models;

namespace Modules.BallisticCalculations.Core.Services;

internal sealed class BallisticCardService : IBallisticCardService
{

    private readonly IBallisticCardCalculator _calculator;

    public BallisticCardService(IBallisticCardCalculator calculator)
    {
        _calculator = calculator;
    }

    public async Task<BallisticCard> GenerateBallisticCard(InputBallisticData data)
    {
        var ballisticCard = await _calculator.Generate(data);

       
        return ballisticCard;
    }

    

}
