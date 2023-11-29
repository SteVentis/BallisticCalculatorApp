namespace Modules.BallisticCalculations.Core.Models;

public sealed class TrajectoryValues
{

    private double distance;
    private double elevation;
    private double windage;
    private double toF;
    private double velocity;

    public double Distance
    {
        get { return Math.Floor(distance); }
        set { distance = value; }
    }

    public double Elevation
    {
        get { return MathAdjustments(elevation); }
        set { elevation = value; }
    }

    public double Windage
    {
        get { return MathAdjustments(windage); }
        set { windage = value; }
    }

    public double ToF
    {
        get { return RoundAndFloor(toF); }
        set { toF = value; }
    }

    public double Velocity
    {
        get { return RoundAndFloor(velocity); }
        set { velocity = value; }
    }

    private double RoundAndFloor(double value)
    {
        return Math.Floor(value * Math.Pow(10, 2)) / Math.Pow(10, 2);
    }

    private double MathAdjustments(double value)
    {
        return Math.Abs(Math.Floor(value * Math.Pow(10, 2)) / Math.Pow(10, 2));
    }
}
