using BallisticCalculator;
using Gehtsoft.Measurements;
using Modules.BallisticCalculations.Core.ObjectValues.RifleData;

namespace Modules.BallisticCalculations.Core.ObjectValues.RifleData;

public sealed record RifleInputData
{
    public RifleInputData(
        RifleName rifleName,
        RiflingStep<DistanceUnit> riflingStep, 
        TwistDirection twistDirection, 
        SightHeight<DistanceUnit> sightHeight, 
        ZeroAtDistance<DistanceUnit> zeroAtDistance)
    {
        RifleName = rifleName;
        RiflingStep = riflingStep;
        TwistDirection = twistDirection;
        SightHeight = sightHeight;
        ZeroAtDistance = zeroAtDistance;
    }

    public RifleName RifleName { get; }
    public RiflingStep<DistanceUnit> RiflingStep { get; }
    public TwistDirection TwistDirection { get; }
    public SightHeight<DistanceUnit> SightHeight { get; }
    public ZeroAtDistance<DistanceUnit> ZeroAtDistance { get; }

   
}
