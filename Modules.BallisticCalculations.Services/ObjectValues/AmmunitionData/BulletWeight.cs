namespace Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;

public readonly struct BulletWeight
{
    public double Value { get; }

    public BulletWeight(double value)
    {
        Value = value;
    }
}
