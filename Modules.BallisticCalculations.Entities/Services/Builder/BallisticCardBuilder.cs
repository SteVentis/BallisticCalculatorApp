using BallisticCalculator;
using Gehtsoft.Measurements;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder;
using Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;
using Modules.BallisticCalculations.Services.ObjectValues.AtmosphereData;
using Modules.BallisticCalculations.Services.ObjectValues.RifleData;
using Modules.BallisticCalculations.Services.ObjectValues.ShotParamsData;
using Modules.BallisticCalculations.Services.ObjectValues.WindData;

namespace Modules.BallisticCalculations.Core.Services.Builder;

internal sealed class BallisticCardBuilder : ITrajectoryPointBuilder
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

    public Task<List<TrajectoryPoint>> Build(Ammunition ammunition, Atmosphere atmosphere, Rifle rifle, ShotParameters shotParams, Wind[] winds)
    {
        TrajectoryCalculator calc = new TrajectoryCalculator();
        var trajectoryPoints = calc.Calculate(ammunition, rifle, atmosphere, shotParams, winds);

        return Task.FromResult(trajectoryPoints.ToList());
    }
}
