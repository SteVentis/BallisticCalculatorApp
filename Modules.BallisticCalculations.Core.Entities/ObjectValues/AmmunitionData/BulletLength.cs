namespace Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;

public sealed record BulletLength<TUnit>
{
    public BulletLength(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }
    public TUnit Unit { get; }
}
