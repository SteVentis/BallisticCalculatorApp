using Gehtsoft.Measurements;

namespace Modules.BallisticCalculations.Core.ObjectValues.AmmunitionData;

public sealed record AmmunitionInputData
{
    public AmmunitionInputData(
        BC ballisticCoefficient,
        BulletWeight<WeightUnit> bulletWeight,
        BulletLength<DistanceUnit> bulletLength,
        BulletDiameter<DistanceUnit> bulletDiameter,
        MuzzleVelocity<VelocityUnit> muzzleVelocity)
    {
        BallisticCoefficient = ballisticCoefficient;
        BulletWeight = bulletWeight;
        BulletLength = bulletLength;
        BulletDiameter = bulletDiameter;
        MuzzleVelocity = muzzleVelocity;
    }

    public BC BallisticCoefficient { get; set; }
    public BulletDiameter<DistanceUnit> BulletDiameter { get; }
    public BulletWeight<WeightUnit> BulletWeight { get; }
    public BulletLength<DistanceUnit> BulletLength { get; }
    public MuzzleVelocity<VelocityUnit> MuzzleVelocity { get; }


}
