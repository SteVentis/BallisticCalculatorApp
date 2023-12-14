using BallisticCalculator;
using Gehtsoft.Measurements;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder;
using Modules.BallisticCalculations.Core.Models;
using Modules.BallisticCalculations.Core.ObjectValues.AmmunitionData;
using Modules.BallisticCalculations.Core.ObjectValues.AtmosphereData;
using Modules.BallisticCalculations.Core.ObjectValues.RifleData;
using Modules.BallisticCalculations.Core.ObjectValues.ShotParamsData;
using Modules.BallisticCalculations.Core.ObjectValues.WindData;
using Modules.BallisticCalculations.Core.Services.Builder.Helper;

namespace Modules.BallisticCalculations.Core.Builder;

internal sealed class BallisticCardBuilder : IBallisticCardBuilder
{
    public Task<Ammunition> CreateAmmunition(AmmunitionInputData input)
    {
        Ammunition ammunition = new Ammunition();
        ammunition.BallisticCoefficient = new BallisticCoefficient(input.BallisticCoefficient.Value, input.BallisticCoefficient.DragTable);
        ammunition.Weight = new Measurement<WeightUnit>(input.BulletWeight.Value, input.BulletWeight.Unit);
        ammunition.BulletLength = new Measurement<DistanceUnit>(input.BulletLength.Value, input.BulletLength.Unit);
        ammunition.BulletDiameter = new Measurement<DistanceUnit>(input.BulletDiameter.Value, input.BulletDiameter.Unit);
        ammunition.MuzzleVelocity = new Measurement<VelocityUnit>(input.MuzzleVelocity.Value, input.MuzzleVelocity.Unit);

        return Task.FromResult(ammunition);
    }

    public Task<Atmosphere> CreateAtmosphere(AtmosphereInputData input)
    {
        Atmosphere atmosphere = new(
        altitude: new Measurement<DistanceUnit>(input.Altitude.Value, input.Altitude.Unit),
        pressure: new Measurement<PressureUnit>(input.Pressure.Value, input.Pressure.Unit),
        temperature: new Measurement<TemperatureUnit>(input.Temperature.Value, input.Temperature.Unit),
        pressureAtSeaLevel: input.PressureAtSeaLevel.Value,
        humidity: input.Humidity.Value);


        return Task.FromResult(atmosphere);
    }

    public Task<Rifle> CreateRifle(RifleInputData input)
    {
        Rifling rifling = new();
        rifling.RiflingStep = new Measurement<DistanceUnit>(input.RiflingStep.Value, input.RiflingStep.Unit);
        rifling.Direction = input.TwistDirection;

        Sight sight = new();
        sight.SightHeight = new Measurement<DistanceUnit>(input.SightHeight.Value, input.SightHeight.Unit);

        ZeroingParameters zeroing = new();
        zeroing.Distance = new Measurement<DistanceUnit>(input.ZeroAtDistance.Value, input.ZeroAtDistance.Unit);

        var rifle = new Rifle
        {
            Rifling = rifling,
            Sight = sight,
            Zero = zeroing
        };

        return Task.FromResult(rifle);
    }

    public Task<Wind[]> CreateWind(WindInputData input)
    {
        Wind[] wind = new Wind[]
        {
            new Wind
            {
                Direction = new Measurement<AngularUnit>(input.WindDirection.Value, input.WindDirection.Unit),
                Velocity = new Measurement<VelocityUnit>(input.WindVelocity.Value, input.WindVelocity.Unit)
            }
        };

        return Task.FromResult(wind);
    }

    public Task<ShotParameters> CreateShotParameters(ShotParamsInputData input, Rifle rifle, Ammunition ammunition, Atmosphere atmosphere)
    {
        TrajectoryCalculator calc = new TrajectoryCalculator();
        var angle = calc.SightAngle(ammunition, rifle, atmosphere);

        ShotParameters shotParameters = new ShotParameters();
        shotParameters.Step = new Measurement<DistanceUnit>(input.Step.Value, input.Step.Unit);
        shotParameters.MaximumDistance = new Measurement<DistanceUnit>(input.MaximumDistance.Value, input.MaximumDistance.Unit);
        shotParameters.SightAngle = angle;

        return Task.FromResult(shotParameters);
    }

    public Task<List<TrajectoryPoint>> CreateTrajectoryPoints(Ammunition ammunition, Atmosphere atmosphere, Rifle rifle, ShotParameters shotParams, Wind[] winds)
    {
        TrajectoryCalculator calc = new TrajectoryCalculator();
        List<TrajectoryPoint> trajectoryPoints = calc.Calculate(ammunition, rifle, atmosphere, shotParams, winds).ToList();

        return Task.FromResult(trajectoryPoints);
    }

    public Task<BallisticCard> Build(RifleInputData rifle, AmmunitionInputData ammo, ShotParamsInputData shotParams, List<TrajectoryPoint> trajectoryPoints)
    {

        BallisticCard ballisticCard = new();
        ballisticCard.RifleName = rifle.RifleName.Value;
        ballisticCard.BulletWeigth = ammo.BulletWeight.Value;
        ballisticCard.BulletDiameter = ammo.BulletDiameter.Value;
        ballisticCard.ZeroDistance = rifle.ZeroAtDistance.Value;
        ballisticCard.DateCreated = DateTime.Now;
        ballisticCard.TrajectoryValues = new List<TrajectoryValues>();

        TrajectoryValues trajectoryValues;

        foreach (var trajectory in trajectoryPoints)
        {
            if (trajectory.Distance.Value >= shotParams.Step.Value)
            {
                trajectoryValues = new TrajectoryValues();
                trajectoryValues.Distance = BallisticCardValuesFormat.Rounding(trajectory.Distance.In(shotParams.MaximumDistance.Unit));
                trajectoryValues.Elevation = BallisticCardValuesFormat.RoundingAndConvertToAbsoluteValues(trajectory.DropAdjustment.In(shotParams.DropUnit.Unit));
                trajectoryValues.Windage = BallisticCardValuesFormat.RoundingAndConvertToAbsoluteValues(trajectory.WindageAdjustment.In(shotParams.WindageUnit.Unit));
                trajectoryValues.ToF = trajectory.Time.TotalSeconds;

                ballisticCard.TrajectoryValues.Add(trajectoryValues);

            }
        }

        return Task.FromResult(ballisticCard);
    }
}
