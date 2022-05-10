using F1GameTelemetryLibrary.Enums;

namespace F1GameTelemetryLibrary.Sessions
{
    /// <summary>
    /// A sample of weather forecast data.
    /// </summary>
    public partial class WeatherForecastSample : IPacketStruct
    {
        /// <summary>
        /// The type of session.
        /// </summary>
        public Enums.SessionType SessionType { get { return sessionType; } }

        /// <summary>
        /// Time in minutes the forecast sample is scheduled for.
        /// </summary>
        public byte TimeOffset { get { return timeOffset; } }

        /// <summary>
        /// The weather status of the forecast sample.
        /// </summary>
        public Enums.WeatherStatus Weather { get { return weather; } }

        /// <summary>
        /// Track temperature in degrees Celcius.
        /// </summary>
        public sbyte TrackTemperature { get { return trackTemperature; } }

        /// <summary>
        /// The change in track temperature from the last forecast sample.
        /// </summary>
        public Enums.TemperatureDelta TrackTemperatureChange { get { return trackTemperatureChange; } }

        /// <summary>
        /// Air temperature in degrees Celcius.
        /// </summary>
        public sbyte AirTemperature { get { return airTemperature; } }

        /// <summary>
        /// The change in air temperature from the last forecast sample.
        /// </summary>
        public Enums.TemperatureDelta AirTemperatureChange { get { return airTemperatureChange; } }

        /// <summary>
        /// The percentage of rain on the track.
        /// </summary>
        public byte RainPercentage { get { return rainPercentage; } }
    }
}
