using F1GameTelemetryLibrary.Enums;

namespace F1GameTelemetryLibrary.Sessions
{
    /// <summary>
    /// A sample of weather forecast data.
    /// </summary>
    internal struct WeatherForecastSample : IPacketStruct
    {
        /// <summary>
        /// The type of session.
        /// </summary>
        Enums.SessionType sessionType;

        /// <summary>
        /// Time in minutes the forecast sample is scheduled for.
        /// </summary>
        byte timeOffset;

        /// <summary>
        /// The weather status of the forecast sample.
        /// </summary>
        Enums.WeatherStatus weather;

        /// <summary>
        /// Track temperature in degrees Celcius.
        /// </summary>
        sbyte trackTemperature;

        /// <summary>
        /// The change in track temperature from the last forecast sample.
        /// </summary>
        Enums.TemperatureDelta trackTemperatureChange;

        /// <summary>
        /// Air temperature in degrees Celcius.
        /// </summary>
        sbyte airTemperature;

        /// <summary>
        /// The change in air temperature from the last forecast sample.
        /// </summary>
        Enums.TemperatureDelta airTemperatureChange;

        /// <summary>
        /// The percentage of rain on the track.
        /// </summary>
        byte rainPercentage;

        public void Unpack(Unpacker unpacker)
        {
            sessionType = (Enums.SessionType)unpacker.NextByte();
            timeOffset = unpacker.NextByte();
            weather = (Enums.WeatherStatus)unpacker.NextByte();
            trackTemperature = unpacker.NextSbyte();
            trackTemperatureChange = (Enums.TemperatureDelta)unpacker.NextSbyte();
            airTemperature = unpacker.NextSbyte();
            airTemperatureChange = (Enums.TemperatureDelta)unpacker.NextSbyte();
            rainPercentage = unpacker.NextByte();
        }
    }
}
