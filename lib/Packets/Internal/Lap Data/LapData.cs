namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Lap data about a particlar car.
    /// </summary>
    partial class LapData : IPacketStruct
    {
        /// <summary>
        /// The previous lap time in milliseconds.
        /// </summary>
        uint lastlapTime;

        /// <summary>
        /// The current lap time in milliseconds.
        /// </summary>
        uint currentLapTime;

        /// <summary>
        /// The current sector one time in milliseconds.
        /// </summary>
        ushort sectorOneTime;

        /// <summary>
        /// The current sector two time in milliseconds.
        /// </summary>
        ushort sectorTwoTime;

        /// <summary>
        /// Distance the car has travelled on the current lap in metres. May be negative if the car has not crossed the start line yet.
        /// </summary>
        float lapDistance;

        /// <summary>
        /// Total distance the car has travelled in the session in metres. May be negative if the car has not crossed the start line yet.
        /// </summary>
        float totalDistance;

        /// <summary>
        /// Delta in seconds for the safety car.
        /// </summary>
        float safetyCarDelta;

        /// <summary>
        /// The current position of the car.
        /// </summary>
        byte carPosition;

        /// <summary>
        /// The current lap number of the car.
        /// </summary>
        byte currentLap;

        /// <summary>
        /// The current pit status of the car.
        /// </summary>
        PitStatus pitStatus;

        /// <summary>
        /// Total number of pit stops the car has made this race.
        /// </summary>
        byte totalPitStops;

        /// <summary>
        /// The current sector the car is in.
        /// </summary>
        byte sector;

        /// <summary>
        /// Is the cars current lap invalid?
        /// </summary>
        bool isCurrentLapInvalid;

        /// <summary>
        /// Accumulated time penalties in seconds to be added to the cars time at the end of the race.
        /// </summary>
        byte penalties;

        /// <summary>
        /// Accumulated number of warnings that have been issued to the car.
        /// </summary>
        byte warnings;

        /// <summary>
        /// The amount of drive-through penalties left for the car to serve.
        /// </summary>
        byte unservedDriveThroughs;

        /// <summary>
        /// The amount of stop-go penalties left for the car to serve.
        /// </summary>
        byte unservedStopGos;

        /// <summary>
        /// The grid position that the car started the race in.
        /// </summary>
        byte gridPosition;

        /// <summary>
        /// The current status of the car.
        /// </summary>
        DriverStatus driverStatus;

        /// <summary>
        /// Result status of the car.
        /// </summary>
        ResultStatus resultStatus;

        /// <summary>
        /// Is the pit lane timer currently active?
        /// </summary>
        bool isPitLaneTimerActive;

        /// <summary>
        /// The current amount of time the car has spent in the pit lane in milliseconds.
        /// </summary>
        ushort pitLaneTime;

        /// <summary>
        /// The current amount of time the car has been stopped in the pit box in milliseconds.
        /// </summary>
        ushort pitStopTime;

        /// <summary>
        /// Will the car serve a penalty at the next pit stop?
        /// </summary>
        bool shouldCarServePenalty;

        public void Unpack(Unpacker unpacker)
        {
            lastlapTime = unpacker.NextUint();
            currentLapTime = unpacker.NextUint();
            sectorOneTime = unpacker.NextUshort();
            sectorTwoTime = unpacker.NextUshort();
            lapDistance = unpacker.NextFloat();
            totalDistance = unpacker.NextFloat();
            safetyCarDelta = unpacker.NextFloat();
            carPosition = unpacker.NextByte();
            currentLap = unpacker.NextByte();
            pitStatus = (PitStatus)unpacker.NextByte();
            totalPitStops = unpacker.NextByte();
            sector = unpacker.NextByte();
            isCurrentLapInvalid = unpacker.NextBool();
            penalties = unpacker.NextByte();
            warnings = unpacker.NextByte();
            unservedDriveThroughs = unpacker.NextByte();
            unservedStopGos = unpacker.NextByte();
            gridPosition = unpacker.NextByte();
            driverStatus = (DriverStatus)unpacker.NextByte();
            resultStatus = (ResultStatus)unpacker.NextByte();
            isPitLaneTimerActive = unpacker.NextBool();
            pitLaneTime = unpacker.NextUshort();
            pitStopTime = unpacker.NextUshort();
            shouldCarServePenalty = unpacker.NextBool();
        }
    }
}
