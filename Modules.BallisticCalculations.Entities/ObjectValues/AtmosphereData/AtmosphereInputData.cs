using BallisticCalculator;
using Gehtsoft.Measurements;

namespace Modules.BallisticCalculations.Core.ObjectValues.AtmosphereData;

public sealed record AtmosphereInputData
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

    public Altitude<DistanceUnit> Altitude { get; }
    public Pressure<PressureUnit> Pressure { get; }
    public Temperature<TemperatureUnit> Temperature { get; }
    public PressureAtSeaLevel PressureAtSeaLevel { get; }
    public Humidity Humidity { get; }

    
}
