namespace Modules.BallisticCalculations.Services.ObjectValues.RifleData;

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