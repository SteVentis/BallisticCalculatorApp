using Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;
using Modules.BallisticCalculations.Services.ObjectValues.AtmosphereData;
using Modules.BallisticCalculations.Services.ObjectValues.RifleData;
using Modules.BallisticCalculations.Services.ObjectValues.ShotParamsData;
using Modules.BallisticCalculations.Services.ObjectValues.WindData;

namespace Modules.BallisticCalculations.Services.Models;

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

    public AmmunitionInputData AmmunitionData { get; set;}
    public RifleInputData RifleData { get; set;}
    public WindInputData WindData { get; set;}
    public AtmosphereInputData AtmosphereData { get; set; }
    public ShotParamsInputData ShotParamsData { get; set;} 

}
