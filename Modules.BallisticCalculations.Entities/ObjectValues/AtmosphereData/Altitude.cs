namespace Modules.BallisticCalculations.Services.ObjectValues.AtmosphereData;

public sealed record Altitude<TUnit>
{
    public Altitude(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value {  get; }

    public TUnit Unit { get; }
}
