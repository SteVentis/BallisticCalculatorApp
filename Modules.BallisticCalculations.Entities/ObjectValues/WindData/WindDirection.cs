namespace Modules.BallisticCalculations.Core.ObjectValues.WindData;

public sealed record WindDirection<TUnit>
{
    public WindDirection(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }

    public TUnit Unit { get; }
}
