using BallisticCalculator;
using Gehtsoft.Measurements;

namespace Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;

public class AmmunitionInputData
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


    public static Task<Ammunition> CreateAmmunition(
        BC bc,
        BulletDiameter<DistanceUnit> bulletDiameter,
        BulletLength<DistanceUnit> bulletLength,
        BulletWeight<WeightUnit> bulletWeight,
        MuzzleVelocity<VelocityUnit> muzzleVelocity)
    {
        Ammunition ammunition = new Ammunition();
        ammunition.BallisticCoefficient = new BallisticCoefficient(bc.Value, bc.DragTable);
        ammunition.Weight = new Measurement<WeightUnit>(bulletWeight.Value, bulletWeight.Unit);
        ammunition.BulletLength = new Measurement<DistanceUnit>(bulletLength.Value, bulletLength.Unit);
        ammunition.BulletDiameter = new Measurement<DistanceUnit>(bulletDiameter.Value, bulletDiameter.Unit);
        ammunition.MuzzleVelocity = new Measurement<VelocityUnit>(muzzleVelocity.Value, muzzleVelocity.Unit);

        return Task.FromResult(ammunition);


    }
}
