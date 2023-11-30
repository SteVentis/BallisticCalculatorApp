namespace Modules.BallisticCalculations.Services.ObjectValues.ShotParamsData;

public sealed record MaximumDistance<TUnit>
{
    public MaximumDistance(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }
    public TUnit Unit { get; }
}