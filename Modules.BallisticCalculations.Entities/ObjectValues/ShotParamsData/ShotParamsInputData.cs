using Gehtsoft.Measurements;
using Modules.BallisticCalculations.Core.ObjectValues.ShotParamsData;

namespace Modules.BallisticCalculations.Core.ObjectValues.ShotParamsData;

public sealed record ShotParamsInputData
{
    public ShotParamsInputData(DropUnit<AngularUnit> dropUnit, WindageUnit<AngularUnit> windageUnit, Step<DistanceUnit> step, MaximumDistance<DistanceUnit> maximumDistance)
    {
        DropUnit = dropUnit;
        WindageUnit = windageUnit;
        Step = step;
        MaximumDistance = maximumDistance;
    }

    
    public DropUnit<AngularUnit> DropUnit { get; }
    public WindageUnit<AngularUnit> WindageUnit { get; }
    public Step<DistanceUnit> Step { get; }
    public MaximumDistance<DistanceUnit> MaximumDistance { get; }
}
