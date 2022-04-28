using F1GameTelemetryLibrary.Packets;
using F1GameTelemetryLibrary.Packets.Enums;
using F1GameTelemetryLibrary.Packets.Structs;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Session packet stores details about a particular session.
    /// </summary>
    internal class SessionPacket : F1Packet, IPacket
    {
        /// <summary>
        /// The weather status.
        /// </summary>
        WeatherStatus weather;

        /// <summary>
        /// Track temperature in degrees Celcius.
        /// </summary>
        sbyte trackTemperature;

        /// <summary>
        /// Air temperature in degrees Celcius.
        /// </summary>
        sbyte airTemperature;

        /// <summary>
        /// The total number of laps in the session.
        /// </summary>
        byte totalLaps;

        /// <summary>
        /// Length of the track in metres.
        /// </summary>
        ushort trackLength;

        /// <summary>
        /// The type of session.
        /// </summary>
        SessionType sessionType;

        /// <summary>
        /// Track identifier. -1 means the track is unknown.
        /// </summary>
        sbyte trackId;

        /// <summary>
        /// The series/class of cars used in the session.
        /// </summary>
        Formula formula;

        /// <summary>
        /// Time remaining in the session in seconds.
        /// </summary>
        ushort sessionTimeLeft;

        /// <summary>
        /// Total duration of the session in seconds.
        /// </summary>
        ushort sessionDuration;

        /// <summary>
        /// Speed limit of the pit lane in kilometres per hour.
        /// </summary>
        byte pitSpeedLimit;

        /// <summary>
        /// Is the game paused?
        /// </summary>
        bool isGamePaused;

        /// <summary>
        /// Is the player spectating another car?
        /// </summary>
        bool isSpectating;

        /// <summary>
        /// The index of the car being spectated.
        /// </summary>
        byte spectatorCarIndex;

        /// <summary>
        /// Is there native support for SLI-Pro?
        /// </summary>
        bool hasNativeSLISupport;

        /// <summary>
        /// The number of marshall zones at the track.
        /// </summary>
        byte marshallZoneCount;

        /// <summary>
        /// Array of marshall zones.
        /// </summary>
        MarshallZone[] marshallZones = new MarshallZone[F1Globals.MAX_MARSHALL_ZONES];

        /// <summary>
        /// The current status of the safety car.
        /// </summary>
        SafetyCarStatus safetyCarStatus;

        /// <summary>
        /// Is the session a network game?
        /// </summary>
        bool isNetworkGame;

        /// <summary>
        /// The number of weather forecast samples available.
        /// </summary>
        byte weatherForecastSampleCount;

        /// <summary>
        /// Array of weather forecast samples.
        /// </summary>
        WeatherForecastSample[] weatherForecastSamples = new WeatherForecastSample[F1Globals.TOTAL_WEATHER_FORECAST_SAMPLES];

        /// <summary>
        /// Are the weather forecast samples approximate?
        /// </summary>
        bool isForecastApproximate;

        /// <summary>
        /// The difficulty of AI cars in the session from 0 to 110.
        /// </summary>
        byte aiDifficulty;

        /// <summary>
        /// Identifier for the season. Persists across saves.
        /// </summary>
        uint seasonLinkIdentifier;

        /// <summary>
        /// Identifier for the weekend. Persists across saves.
        /// </summary>
        uint weekendLinkIdentifier;

        /// <summary>
        /// Identifier for the session. Persists across saves.
        /// </summary>
        uint sessionLinkIdentifier;

        /// <summary>
        /// The lap number that the pit window opens for the players selected strategy.
        /// </summary>
        byte pitStopWindowIdealLap;

        /// <summary>
        /// The lap number that the pit window closes for the players selected strategy.
        /// </summary>
        byte pitStopWindowLatestLap;

        /// <summary>
        /// The track position the game predicts the player to end up in if they were to pit.
        /// </summary>
        byte pitStopRejoinPosition;

        /// <summary>
        /// The assists allowed in the session.
        /// </summary>
        Assists allowedAssists = new();

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new(packedData);

            weather = (WeatherStatus)unpacker.NextByte();
            trackTemperature = unpacker.NextSbyte();
            airTemperature = unpacker.NextSbyte();
            totalLaps = unpacker.NextByte();
            trackLength = unpacker.NextUshort();
            sessionType = (SessionType)unpacker.NextByte();
            trackId = unpacker.NextSbyte();
            formula = (Formula)unpacker.NextByte();
            sessionTimeLeft = unpacker.NextUshort();
            sessionDuration = unpacker.NextUshort();
            pitSpeedLimit = unpacker.NextByte();
            isGamePaused = unpacker.NextBool();
            isSpectating = unpacker.NextBool();
            spectatorCarIndex = unpacker.NextByte();
            hasNativeSLISupport = unpacker.NextBool();
            marshallZoneCount = unpacker.NextByte();
            for (int i = 0; i < marshallZones.Length; i++)
            {
                marshallZones[i].Unpack(unpacker);
            }
            safetyCarStatus = (SafetyCarStatus)unpacker.NextByte();
            isNetworkGame = unpacker.NextBool();
            weatherForecastSampleCount = unpacker.NextByte();
            for (int i = 0; i < weatherForecastSamples.Length; i++)
            {
                weatherForecastSamples[i].Unpack(unpacker);
            }
            isForecastApproximate = unpacker.NextBool();
            aiDifficulty = unpacker.NextByte();
            seasonLinkIdentifier = unpacker.NextUint();
            weekendLinkIdentifier = unpacker.NextUint();
            sessionLinkIdentifier = unpacker.NextUint();
            pitStopWindowIdealLap = unpacker.NextByte();
            pitStopWindowLatestLap = unpacker.NextByte();
            pitStopRejoinPosition = unpacker.NextByte();
            allowedAssists.Unpack(unpacker);
        }
    }
}
