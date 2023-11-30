using Gehtsoft.Measurements;
using Modules.BallisticCalculations.Core.ObjectValues.ShotParamsData;

namespace Modules.BallisticCalculations.Services.ObjectValues.ShotParamsData;

public sealed record ShotParamsInputData
{
    public ShotParamsInputData(DropUnit<AngularUnit> dropUnit, WindageUnit<AngularUnit> windageUnit, Step<DistanceUnit> step, MaximumDistance<DistanceUnit> maximumDistance)
    {
        DropUnit = dropUnit;
        WindageUnit = windageUnit;
        Step = step;
        MaximumDistance = maximumDistance;
    }

    
    public DropUnit<AngularUnit> DropUnit { get; set; }
    public WindageUnit<AngularUnit> WindageUnit { get; set; }
    public Step<DistanceUnit> Step { get; private set; }
    public MaximumDistance<DistanceUnit> MaximumDistance { get; private set; }
}
