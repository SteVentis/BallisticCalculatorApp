using BallisticCalculator;
using Modules.BallisticCalculations.Core.Models;
using Modules.BallisticCalculations.Core.ObjectValues.AmmunitionData;
using Modules.BallisticCalculations.Core.ObjectValues.AtmosphereData;
using Modules.BallisticCalculations.Core.ObjectValues.RifleData;
using Modules.BallisticCalculations.Core.ObjectValues.ShotParamsData;
using Modules.BallisticCalculations.Core.ObjectValues.WindData;

namespace Modules.BallisticCalculations.Core.Abstractions.IBuilder;

public interface IBallisticCardBuilder
{
    Task<Ammunition> CreateAmmunition(AmmunitionInputData input);
    Task<Atmosphere> CreateAtmosphere(AtmosphereInputData input);
    Task<Rifle> CreateRifle(RifleInputData input);
    Task<Wind[]> CreateWind(WindInputData input);
    Task<ShotParameters> CreateShotParameters(ShotParamsInputData input, Rifle rifle, Ammunition ammunition, Atmosphere atmosphere);
    Task<List<TrajectoryPoint>> CreateTrajectoryPoints(Ammunition ammunition, Atmosphere atmosphere, Rifle rifle, ShotParameters shotParams, Wind[] winds);
    Task<BallisticCard> Build(RifleInputData rifle, AmmunitionInputData ammo, ShotParamsInputData shotParams, List<TrajectoryPoint> trajectoryPoints);
}
