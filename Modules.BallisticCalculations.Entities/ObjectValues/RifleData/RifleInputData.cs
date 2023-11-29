using BallisticCalculator;
using Gehtsoft.Measurements;
using Modules.BallisticCalculations.Core.ObjectValues.RifleData;

namespace Modules.BallisticCalculations.Services.ObjectValues.RifleData;

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

    public RifleName RifleName { get; private set; }
    public RiflingStep<DistanceUnit> RiflingStep { get; private set; }
    public TwistDirection TwistDirection { get; private set; }
    public SightHeight<DistanceUnit> SightHeight { get; private set; }
    public ZeroAtDistance<DistanceUnit> ZeroAtDistance { get; private set; }

   
}
