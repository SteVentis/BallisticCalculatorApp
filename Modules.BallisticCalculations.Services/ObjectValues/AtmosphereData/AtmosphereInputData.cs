using BallisticCalculator;
using Gehtsoft.Measurements;

namespace Modules.BallisticCalculations.Services.ObjectValues.AtmosphereData;

public class AtmosphereInputData
{
    public AtmosphereInputData(
        Altitude<DistanceUnit> altitude, 
        Pressure<PressureUnit> pressure, 
        Temperature<TemperatureUnit> temperature, 
        PressureAtSeaLevel pressureAtSeaLevel, 
        Humidity humidity)
    {
        Altitude = altitude;
        Pressure = pressure;
        Temperature = temperature;
        PressureAtSeaLevel = pressureAtSeaLevel;
        Humidity = humidity;
    }

    public Altitude<DistanceUnit> Altitude { get; private set; }
    public Pressure<PressureUnit> Pressure { get; private set; }
    public Temperature<TemperatureUnit> Temperature { get; private set; }
    public PressureAtSeaLevel PressureAtSeaLevel { get; private set; }
    public Humidity Humidity { get; private set; }

    public static Task<Atmosphere> CreateAtmosphere(
        Altitude<DistanceUnit> altitude,
        Pressure<PressureUnit> pressure,
        Temperature<TemperatureUnit> temperature,
        PressureAtSeaLevel pressureAtSeaLevel,
        Humidity humidity)
    {
        Atmosphere atmosphere = new(
            altitude: new Measurement<DistanceUnit>(altitude.Value, altitude.Unit),
            pressure: new Measurement<PressureUnit>(pressure.Value, pressure.Unit),
            temperature: new Measurement<TemperatureUnit>(temperature.Value, temperature.Unit),
            pressureAtSeaLevel: pressureAtSeaLevel.Value,
            humidity: humidity.Value);

        return Task.FromResult(atmosphere);
    }
}
