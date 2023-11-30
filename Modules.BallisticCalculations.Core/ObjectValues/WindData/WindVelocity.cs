namespace Modules.BallisticCalculations.Core.ObjectValues.WindData;

public sealed record WindVelocity<TUnit>
{
    public WindVelocity(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }

    public TUnit Unit { get; }
}