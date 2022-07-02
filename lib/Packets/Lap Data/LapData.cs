namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Lap data about a particlar car.
    /// </summary>
    public partial class LapData : IPacketStruct
    {
        /// <summary>
        /// The previous lap time in milliseconds.
        /// </summary>
        public uint LastlapTime { get { return lastlapTime; } }

        /// <summary>
        /// The current lap time in milliseconds.
        /// </summary>
        public uint CurrentLapTime { get { return currentLapTime; } }

        /// <summary>
        /// The current sector one time in milliseconds.
        /// </summary>
        public ushort SectorOneTime { get { return sectorOneTime; } }

        /// <summary>
        /// The current sector two time in milliseconds.
        /// </summary>
        public ushort SectorTwoTime { get { return sectorTwoTime; } }

        /// <summary>
        /// Distance the car has travelled on the current lap in metres. May be negative if the car has not crossed the start line yet.
        /// </summary>
        public float LapDistance { get { return lapDistance; } }

        /// <summary>
        /// Total distance the car has travelled in the session in metres. May be negative if the car has not crossed the start line yet.
        /// </summary>
        public float TotalDistance { get { return totalDistance; } }

        /// <summary>
        /// Delta in seconds for the safety car.
        /// </summary>
        public float SafetyCarDelta { get { return safetyCarDelta; } }

        /// <summary>
        /// The current position of the car.
        /// </summary>
        public byte CarPosition { get { return carPosition; } }

        /// <summary>
        /// The current lap number of the car.
        /// </summary>
        public byte CurrentLap { get { return currentLap; } }

        /// <summary>
        /// The current pit status of the car.
        /// </summary>
        public PitStatus PitStatus { get { return pitStatus; } }

        /// <summary>
        /// Total number of pit stops the car has made this race.
        /// </summary>
        public byte TotalPitStops { get { return totalPitStops; } }

        /// <summary>
        /// The current sector the car is in.
        /// </summary>
        public byte Sector { get { return sector; } }

        /// <summary>
        /// Is the cars current lap invalid?
        /// </summary>
        public bool IsCurrentLapInvalid { get { return isCurrentLapInvalid; } }

        /// <summary>
        /// Accumulated time penalties in seconds to be added to the cars time at the end of the race.
        /// </summary>
        public byte Penalties { get { return penalties; } }

        /// <summary>
        /// Accumulated number of warnings that have been issued to the car.
        /// </summary>
        public byte Warnings { get { return warnings; } }

        /// <summary>
        /// The amount of drive-through penalties left for the car to serve.
        /// </summary>
        public byte UnservedDriveThroughs { get { return unservedDriveThroughs; } }

        /// <summary>
        /// The amount of stop-go penalties left for the car to serve.
        /// </summary>
        public byte UnservedStopGos { get { return unservedStopGos; } }

        /// <summary>
        /// The grid position that the car started the race in.
        /// </summary>
        public byte GridPosition { get { return gridPosition; } }

        /// <summary>
        /// The current status of the car.
        /// </summary>
        public DriverStatus DriverStatus { get { return driverStatus; } }

        /// <summary>
        /// Result status of the car.
        /// </summary>
        public ResultStatus ResultStatus { get { return resultStatus; } }

        /// <summary>
        /// Is the pit lane timer currently active?
        /// </summary>
        public bool IsPitLaneTimerActive { get { return isPitLaneTimerActive; } }

        /// <summary>
        /// The current amount of time the car has spent in the pit lane in milliseconds.
        /// </summary>
        public ushort PitLaneTime { get { return pitLaneTime; } }

        /// <summary>
        /// The current amount of time the car has been stopped in the pit box in milliseconds.
        /// </summary>
        public ushort PitStopTime { get { return pitStopTime; } }

        /// <summary>
        /// Will the car serve a penalty at the next pit stop?
        /// </summary>
        public bool ShouldCarServePenalty { get { return shouldCarServePenalty; } }
    }
}
