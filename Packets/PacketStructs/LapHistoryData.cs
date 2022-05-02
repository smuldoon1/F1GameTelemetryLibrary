namespace F1GameTelemetryLibrary.SessionHistory
{
    /// <summary>
    /// Stores historical data for each lap done by a particular car.
    /// </summary>
    internal class LapHistoryData : IPacketStruct
    {
        /// <summary>
        /// Lap time in milliseconds.
        /// </summary>
        uint lapTime;

        /// <summary>
        /// The current sector one time in milliseconds.
        /// </summary>
        ushort sectorOneTime;

        /// <summary>
        /// The current sector two time in milliseconds.
        /// </summary>
        ushort sectorTwoTime;

        /// <summary>
        /// The current sector three time in milliseconds.
        /// </summary>
        ushort sectorThreeTime;

        /// <summary>
        /// Bit flags for the validity of the lap and for each sector.
        /// </summary>
        Enums.LapValidityFlags lapValidBitFlags;

        public void Unpack(Unpacker unpacker)
        {
            lapTime = unpacker.NextUint();
            sectorOneTime = unpacker.NextUshort();
            sectorTwoTime = unpacker.NextUshort();
            sectorThreeTime = unpacker.NextUshort();
            lapValidBitFlags = (Enums.LapValidityFlags)unpacker.NextByte();
        }
    }
}
