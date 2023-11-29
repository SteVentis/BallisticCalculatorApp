using BallisticCalculator;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;
using Modules.BallisticCalculations.Services.Models;

namespace Modules.BallisticCalculations.Core.Services.Builder.Director;

public sealed class BallisticCardCalculator : ITrajectoryPointCalculator
{
    private readonly ITrajectoryPointBuilder _builder;

    public BallisticCardCalculator(ITrajectoryPointBuilder builder)
    {
        _builder = builder;
    }

    public async Task<List<TrajectoryPoint>> GenerateBallisticCard(InputBallisticData inputBallisticData)
    {
        var rifle = await _builder.CreateRifle(inputBallisticData.RifleData);
        var ammo = await _builder.CreateAmmunition(inputBallisticData.AmmunitionData);
        var atmosphere = await _builder.CreateAtmosphere(inputBallisticData.AtmosphereData);
        var wind = await _builder.CreateWind(inputBallisticData.WindData);
        var shotParams = await _builder.CreateShotParameters(inputBallisticData.ShotParamsData, rifle, ammo, atmosphere);

        return await _builder.Build(ammo, atmosphere, rifle, shotParams, wind);
    }
}
