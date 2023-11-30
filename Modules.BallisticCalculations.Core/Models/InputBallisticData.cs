using Modules.BallisticCalculations.Core.ObjectValues.AmmunitionData;
using Modules.BallisticCalculations.Core.ObjectValues.AtmosphereData;
using Modules.BallisticCalculations.Core.ObjectValues.RifleData;
using Modules.BallisticCalculations.Core.ObjectValues.ShotParamsData;
using Modules.BallisticCalculations.Core.ObjectValues.WindData;

namespace Modules.BallisticCalculations.Core.Models;

public class InputBallisticData
{
    public InputBallisticData(AmmunitionInputData ammunitionData, 
        RifleInputData rifleData, 
        WindInputData windData, 
        AtmosphereInputData atmosphereData, 
        ShotParamsInputData shotParamsData)
    {
        AmmunitionData = ammunitionData;
        RifleData = rifleData;
        WindData = windData;
        AtmosphereData = atmosphereData;
        ShotParamsData = shotParamsData;
    }

    public AmmunitionInputData AmmunitionData { get; }
    public RifleInputData RifleData { get; }
    public WindInputData WindData { get; }
    public AtmosphereInputData AtmosphereData { get; }
    public ShotParamsInputData ShotParamsData { get; } 

}
