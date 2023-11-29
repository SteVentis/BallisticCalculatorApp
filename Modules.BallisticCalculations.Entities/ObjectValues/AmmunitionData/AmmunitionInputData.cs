using BallisticCalculator;
using Gehtsoft.Measurements;
using Modules.BallisticCalculations.Core.Abstractions;

namespace Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;

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
    public BulletDiameter<DistanceUnit> BulletDiameter { get; private set; }
    public BulletWeight<WeightUnit> BulletWeight { get; private set; }
    public BulletLength<DistanceUnit> BulletLength { get; private set; }
    public MuzzleVelocity<VelocityUnit> MuzzleVelocity { get; private set; }


}
