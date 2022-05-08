namespace F1GameTelemetryLibrary.SessionHistory
{
    /// <summary>
    /// Session history packet stores lap times and tyre usage during the session for a specific car.
    /// </summary>
    internal class SessionHistoryPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Index of the car this data relates to.
        /// </summary>
        byte carIndex;

        /// <summary>
        /// Number of laps in the data including partially completed laps.
        /// </summary>
        byte totalLaps;

        /// <summary>
        /// Number of tyre stints in the data.
        /// </summary>
        byte tyreStints;

        /// <summary>
        /// Lap the cars best lap time was achieved on.
        /// </summary>
        byte bestLapTimeLap;

        /// <summary>
        /// Lap the best first sector was achieved on.
        /// </summary>
        byte bestSectorOneLap;

        /// <summary>
        /// Lap the best second sector was achieved on.
        /// </summary>
        byte bestSectorTwoLap;

        /// <summary>
        /// Lap the best third sector was achieved on.
        /// </summary>
        byte bestSectorThreeLap;

        /// <summary>
        /// Historical data of all laps done by this car.
        /// </summary>
        LapHistoryData[] lapHistoryData = new LapHistoryData[F1Globals.MAX_LAP_HISTORY_DATA];

        /// <summary>
        /// Historical data of all tyre stints by this car.
        /// </summary>
        TyreStintsHistoryData[] tyreStintsHistoryData = new TyreStintsHistoryData[F1Globals.MAX_TYRE_STINTS_HISTORY_DATA];

        public SessionHistoryPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            carIndex = unpacker.NextByte();
            totalLaps = unpacker.NextByte();
            tyreStints = unpacker.NextByte();
            bestLapTimeLap = unpacker.NextByte();
            bestSectorOneLap = unpacker.NextByte();
            bestSectorTwoLap = unpacker.NextByte();
            bestSectorThreeLap = unpacker.NextByte();
            for (int i = 0; i < lapHistoryData.Length; i++)
            {
                lapHistoryData[i] = new LapHistoryData();
                lapHistoryData[i].Unpack(unpacker);
            }
            for (int i = 0; i < tyreStintsHistoryData.Length; i++)
            {
                tyreStintsHistoryData[i] = new TyreStintsHistoryData();
                tyreStintsHistoryData[i].Unpack(unpacker);
            }

            unpacker.Finish();
        }
    }
}
