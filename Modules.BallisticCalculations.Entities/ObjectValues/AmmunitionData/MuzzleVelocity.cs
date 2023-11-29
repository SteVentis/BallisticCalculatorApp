namespace Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;

public sealed record MuzzleVelocity<TUnit>
{
    public MuzzleVelocity(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }

    public TUnit Unit { get; }
}
