using BallisticCalculator;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;
using Modules.BallisticCalculations.Core.Models;

namespace Modules.BallisticCalculations.Core.Builder.Director;

public sealed class BallisticCardCalculator : IBallisticCardCalculator
{
    private readonly IBallisticCardBuilder _builder;

    public BallisticCardCalculator(IBallisticCardBuilder builder)
    {
        _builder = builder;
    }

    public async Task<BallisticCard> Generate(InputBallisticData inputBallisticData)
    {
        Rifle rifle = await _builder.CreateRifle(inputBallisticData.RifleData);
        Ammunition ammo = await _builder.CreateAmmunition(inputBallisticData.AmmunitionData);
        Atmosphere atmosphere = await _builder.CreateAtmosphere(inputBallisticData.AtmosphereData);
        Wind[] wind = await _builder.CreateWind(inputBallisticData.WindData);
        ShotParameters shotParams = await _builder.CreateShotParameters(inputBallisticData.ShotParamsData, rifle, ammo, atmosphere);
        List<TrajectoryPoint> trajectoryPoints = await _builder.CreateTrajectoryPoints(ammo, atmosphere, rifle, shotParams, wind);


        return await _builder.Build(inputBallisticData.RifleData,inputBallisticData.AmmunitionData, inputBallisticData.ShotParamsData, trajectoryPoints);
    }
}
