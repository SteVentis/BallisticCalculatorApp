using BallisticCalculator;
using Gehtsoft.Measurements;

namespace Modules.BallisticCalculations.Services.ObjectValues.AtmosphereData;

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

    public Altitude<DistanceUnit> Altitude { get; private set; }
    public Pressure<PressureUnit> Pressure { get; private set; }
    public Temperature<TemperatureUnit> Temperature { get; private set; }
    public PressureAtSeaLevel PressureAtSeaLevel { get; private set; }
    public Humidity Humidity { get; private set; }

    
}
