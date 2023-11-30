namespace Modules.BallisticCalculations.Services.ObjectValues.AtmosphereData;

public sealed record Pressure<TUnit>
{
    public Pressure(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }

    public TUnit Unit { get; }
}
