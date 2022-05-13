namespace F1GameTelemetry
{
    /// <summary>
    /// A sample of weather forecast data.
    /// </summary>
    partial class WeatherForecastSample : IPacketStruct
    {
        /// <summary>
        /// The type of session.
        /// </summary>
        SessionType sessionType;

        /// <summary>
        /// Time in minutes the forecast sample is scheduled for.
        /// </summary>
        byte timeOffset;

        /// <summary>
        /// The weather status of the forecast sample.
        /// </summary>
        WeatherStatus weather;

        /// <summary>
        /// Track temperature in degrees Celcius.
        /// </summary>
        sbyte trackTemperature;

        /// <summary>
        /// The change in track temperature from the last forecast sample.
        /// </summary>
        TemperatureDelta trackTemperatureChange;

        /// <summary>
        /// Air temperature in degrees Celcius.
        /// </summary>
        sbyte airTemperature;

        /// <summary>
        /// The change in air temperature from the last forecast sample.
        /// </summary>
        TemperatureDelta airTemperatureChange;

        /// <summary>
        /// The percentage of rain on the track.
        /// </summary>
        byte rainPercentage;

        public void Unpack(Unpacker unpacker)
        {
            sessionType = (SessionType)unpacker.NextByte();
            timeOffset = unpacker.NextByte();
            weather = (WeatherStatus)unpacker.NextByte();
            trackTemperature = unpacker.NextSbyte();
            trackTemperatureChange = (TemperatureDelta)unpacker.NextSbyte();
            airTemperature = unpacker.NextSbyte();
            airTemperatureChange = (TemperatureDelta)unpacker.NextSbyte();
            rainPercentage = unpacker.NextByte();
        }
    }
}
