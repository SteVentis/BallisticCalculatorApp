namespace Modules.BallisticCalculations.Services.ObjectValues.ShotParamsData;

public sealed record Step<TUnit>
{
    public Step(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }
    public TUnit Unit { get; }
}
