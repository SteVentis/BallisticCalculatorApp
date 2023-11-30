using BallisticCalculator;
using Gehtsoft.Measurements;

namespace Modules.BallisticCalculations.Services.ObjectValues.WindData;

public sealed record WindInputData
{
    public WindInputData(WindDirection<AngularUnit> direction, WindVelocity<VelocityUnit> velocity)
    {
        WindDirection = direction;
        WindVelocity = velocity;
    }

    public WindDirection<AngularUnit> WindDirection { get; private set; }
    public WindVelocity<VelocityUnit> WindVelocity { get; private set; }

}
