using BallisticCalculator;
using Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;
using Modules.BallisticCalculations.Services.ObjectValues.AtmosphereData;
using Modules.BallisticCalculations.Services.ObjectValues.RifleData;
using Modules.BallisticCalculations.Services.ObjectValues.ShotParamsData;
using Modules.BallisticCalculations.Services.ObjectValues.WindData;

namespace Modules.BallisticCalculations.Core.Abstractions.IBuilder;

public interface ITrajectoryPointBuilder
{
    Task<Ammunition> CreateAmmunition(AmmunitionInputData input);
    Task<Atmosphere> CreateAtmosphere(AtmosphereInputData input);
    Task<Rifle> CreateRifle(RifleInputData input);
    Task<Wind[]> CreateWind(WindInputData input);
    Task<ShotParameters> CreateShotParameters(ShotParamsInputData input, Rifle rifle, Ammunition ammunition, Atmosphere atmosphere);
    Task<List<TrajectoryPoint>> Build(Ammunition ammunition, Atmosphere atmosphere, Rifle rifle, ShotParameters shotParams, Wind[] winds);

}
