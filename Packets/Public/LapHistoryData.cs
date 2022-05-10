namespace F1GameTelemetryLibrary.SessionHistory
{
    /// <summary>
    /// Stores historical data for each lap done by a particular car.
    /// </summary>
    public partial class LapHistoryData : IPacketStruct
    {
        /// <summary>
        /// Lap time in milliseconds.
        /// </summary>
        public uint LapTime { get { return lapTime; } }

        /// <summary>
        /// The current sector one time in milliseconds.
        /// </summary>
        public ushort SectorOneTime { get { return sectorOneTime; } }

        /// <summary>
        /// The current sector two time in milliseconds.
        /// </summary>
        public ushort SectorTwoTime { get { return sectorTwoTime; } }

        /// <summary>
        /// The current sector three time in milliseconds.
        /// </summary>
        public ushort SectorThreeTime { get { return sectorThreeTime; } }

        /// <summary>
        /// Bit flags for the validity of the lap and for each sector.
        /// </summary>
        public Enums.LapValidityFlags LapValidBitFlags { get { return lapValidBitFlags; } }
    }
}
