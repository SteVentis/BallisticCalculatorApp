using Gehtsoft.Measurements;

namespace Modules.BallisticCalculations.Core.ObjectValues.WindData;

public sealed record WindInputData
{
    public WindInputData(WindDirection<AngularUnit> windDirection, WindVelocity<VelocityUnit> windVelocity)
    {
        WindDirection = windDirection;
        WindVelocity = windVelocity;
    }

    public WindDirection<AngularUnit> WindDirection { get; }
    public WindVelocity<VelocityUnit> WindVelocity { get; }

}
