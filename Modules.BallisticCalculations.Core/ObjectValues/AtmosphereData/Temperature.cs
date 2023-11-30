namespace Modules.BallisticCalculations.Core.ObjectValues.AtmosphereData;

public sealed record Temperature<TUnit>
{
    public Temperature(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }

    public TUnit Unit { get; }
}
