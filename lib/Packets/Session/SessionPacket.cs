namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Session packet stores details about a particular session.
    /// </summary>
    public partial class SessionPacket : F1Packet, IPacket
    {
        /// <summary>
        /// The weather status.
        /// </summary>
        public WeatherStatus Weather { get { return weather; } }

        /// <summary>
        /// Track temperature in degrees Celcius.
        /// </summary>
        public sbyte TrackTemperature { get { return trackTemperature; } }

        /// <summary>
        /// Air temperature in degrees Celcius.
        /// </summary>
        public sbyte AirTemperature { get { return airTemperature; } }

        /// <summary>
        /// The total number of laps in the session.
        /// </summary>
        public byte TotalLaps { get { return totalLaps; } }

        /// <summary>
        /// Length of the track in metres.
        /// </summary>
        public ushort TrackLength { get { return trackLength; } }

        /// <summary>
        /// The type of session.
        /// </summary>
        public SessionType SessionType { get { return sessionType; } }

        /// <summary>
        /// Track identifier. -1 means the track is unknown.
        /// </summary>
        public sbyte TrackId { get { return trackId; } }

        /// <summary>
        /// The series/class of cars used in the session.
        /// </summary>
        public Formula Formula { get { return formula; } }

        /// <summary>
        /// Time remaining in the session in seconds.
        /// </summary>
        public ushort SessionTimeLeft { get { return sessionTimeLeft; } }

        /// <summary>
        /// Total duration of the session in seconds.
        /// </summary>
        public ushort SessionDuration { get { return sessionDuration; } }

        /// <summary>
        /// Speed limit of the pit lane in kilometres per hour.
        /// </summary>
        public byte PitSpeedLimit { get { return pitSpeedLimit; } }

        /// <summary>
        /// Is the game paused?
        /// </summary>
        public bool IsGamePaused { get { return isGamePaused; } }

        /// <summary>
        /// Is the player spectating another car?
        /// </summary>
        public bool IsSpectating { get { return isSpectating; } }

        /// <summary>
        /// The index of the car being spectated.
        /// </summary>
        public byte SpectatorCarIndex { get { return spectatorCarIndex; } }

        /// <summary>
        /// Is there native support for SLI-Pro?
        /// </summary>
        public bool HasNativeSLISupport { get { return hasNativeSLISupport; } }

        /// <summary>
        /// The number of marshall zones at the track.
        /// </summary>
        public byte MarshallZoneCount { get { return marshallZoneCount; } }

        /// <summary>
        /// Array of marshall zones.
        /// </summary>
        public MarshallZone[] MarshallZones { get { return marshallZones; } }

        /// <summary>
        /// The current status of the safety car.
        /// </summary>
        public SafetyCarStatus SafetyCarStatus { get { return safetyCarStatus; } }

        /// <summary>
        /// Is the session a network game?
        /// </summary>
        public bool IsNetworkGame { get { return isNetworkGame; } }

        /// <summary>
        /// The number of weather forecast samples available.
        /// </summary>
        public byte WeatherForecastSampleCount { get { return weatherForecastSampleCount; } }

        /// <summary>
        /// Array of weather forecast samples.
        /// </summary>
        public WeatherForecastSample[] WeatherForecastSamples { get { return weatherForecastSamples; } }

        /// <summary>
        /// Are the weather forecast samples approximate?
        /// </summary>
        public bool IsForecastApproximate { get { return isForecastApproximate; } }

        /// <summary>
        /// The difficulty of AI cars in the session from 0 to 110.
        /// </summary>
        public byte AiDifficulty { get { return aiDifficulty; } }

        /// <summary>
        /// Identifier for the season. Persists across saves.
        /// </summary>
        public uint SeasonLinkIdentifier { get { return seasonLinkIdentifier; } }

        /// <summary>
        /// Identifier for the weekend. Persists across saves.
        /// </summary>
        public uint WeekendLinkIdentifier { get { return weekendLinkIdentifier; } }

        /// <summary>
        /// Identifier for the session. Persists across saves.
        /// </summary>
        public uint SessionLinkIdentifier { get { return sessionLinkIdentifier; } }

        /// <summary>
        /// The lap number that the pit window opens for the players selected strategy.
        /// </summary>
        public byte PitStopWindowIdealLap { get { return pitStopWindowIdealLap; } }

        /// <summary>
        /// The lap number that the pit window closes for the players selected strategy.
        /// </summary>
        public byte PitStopWindowLatestLap { get { return pitStopWindowLatestLap; } }

        /// <summary>
        /// The track position the game predicts the player to end up in if they were to pit.
        /// </summary>
        public byte PitStopRejoinPosition { get { return pitStopRejoinPosition; } }

        /// <summary>
        /// The assists allowed in the session.
        /// </summary>
        public Assists AllowedAssists { get { return allowedAssists; } }
    }
}
