namespace Modules.BallisticCalculations.Services.ObjectValues.RifleData;

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
