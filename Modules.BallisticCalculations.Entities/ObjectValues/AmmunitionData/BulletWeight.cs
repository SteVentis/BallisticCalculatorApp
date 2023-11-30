namespace Modules.BallisticCalculations.Core.ObjectValues.AmmunitionData;

public sealed record BulletWeight<TUnit>
{
    public BulletWeight(double value, TUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }
    public TUnit Unit { get; }

}
