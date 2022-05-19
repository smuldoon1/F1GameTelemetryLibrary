namespace F1GameTelemetry
{
    /// <summary>
    /// Session history packet stores lap times and tyre usage during the session for a specific car.
    /// </summary>
    public partial class SessionHistoryPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Index of the car this data relates to.
        /// </summary>
        public byte CarIndex { get { return carIndex; } }

        /// <summary>
        /// Number of laps in the data including partially completed laps.
        /// </summary>
        public byte TotalLaps { get { return totalLaps; } }

        /// <summary>
        /// Number of tyre stints in the data.
        /// </summary>
        public byte TyreStints { get { return tyreStints; } }

        /// <summary>
        /// Lap the cars best lap time was achieved on.
        /// </summary>
        public byte BestLapTimeLap { get { return bestLapTimeLap; } }

        /// <summary>
        /// Lap the best first sector was achieved on.
        /// </summary>
        public byte BestSectorOneLap { get { return bestSectorOneLap; } }

        /// <summary>
        /// Lap the best second sector was achieved on.
        /// </summary>
        public byte BestSectorTwoLap { get { return bestSectorTwoLap; } }

        /// <summary>
        /// Lap the best third sector was achieved on.
        /// </summary>
        public byte BestSectorThreeLap { get { return bestSectorThreeLap; } }

        /// <summary>
        /// Historical data of all laps done by this car.
        /// </summary>
        public LapHistoryData[] LapHistoryData { get { return lapHistoryData; } }

        /// <summary>
        /// Historical data of all tyre stints by this car.
        /// </summary>
        public TyreStintsHistoryData[] TyreStintsHistoryData { get { return tyreStintsHistoryData; } }
    }
}
