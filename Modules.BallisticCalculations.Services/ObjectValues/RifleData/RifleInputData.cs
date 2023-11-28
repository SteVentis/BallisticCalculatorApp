using BallisticCalculator;
using Gehtsoft.Measurements;

namespace Modules.BallisticCalculations.Services.ObjectValues.RifleData;

public sealed class RifleInputData
{
    public RifleInputData(
        RiflingStep<DistanceUnit> riflingStep, 
        TwistDirection twistDirection, 
        SightHeight<DistanceUnit> sightHeight, 
        ZeroAtDistance<DistanceUnit> zeroAtDistance)
    {
        RiflingStep = riflingStep;
        TwistDirection = twistDirection;
        SightHeight = sightHeight;
        ZeroAtDistance = zeroAtDistance;
    }

    public RiflingStep<DistanceUnit> RiflingStep { get; private set; }
    public TwistDirection TwistDirection { get; private set; }
    public SightHeight<DistanceUnit> SightHeight { get; private set; }
    public ZeroAtDistance<DistanceUnit> ZeroAtDistance { get; private set; }

    public static Task<Rifle> CreateRifle(
        RiflingStep<DistanceUnit> riflingStep,
        TwistDirection twistDirection,
        SightHeight<DistanceUnit> sightHeight,
        ZeroAtDistance<DistanceUnit> zeroAtDistance)
    {
        Rifling rifling = new();
        rifling.RiflingStep = new Measurement<DistanceUnit>(riflingStep.Value, riflingStep.Unit);
        rifling.Direction = twistDirection;

        Sight sight = new();
        sight.SightHeight = new Measurement<DistanceUnit>(sightHeight.Value, sightHeight.Unit);

        ZeroingParameters zeroing = new();
        zeroing.Distance = new Measurement<DistanceUnit>(zeroAtDistance.Value, zeroAtDistance.Unit);

        var rifle = new Rifle
        {
            Rifling = rifling,
            Sight = sight,
            Zero = zeroing
        };

        return Task.FromResult(rifle);
    }
}

public sealed record RiflingStep<Tunit>
{
    public RiflingStep(double value, Tunit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }
    public Tunit Unit { get; }
}

public sealed record SightHeight<Tunit>
{
    public SightHeight(double value, Tunit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }
    public Tunit Unit { get; }
}

public sealed record ZeroAtDistance<Tunit>
{
    public ZeroAtDistance(double value, Tunit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }
    public Tunit Unit { get; }
}