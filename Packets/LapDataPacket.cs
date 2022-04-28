namespace F1GameTelemetryLibrary.Laps
{
    /// <summary>
    /// Lap data packet gives details about the laps of all cars in the session.
    /// </summary>
    internal class LapDataPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of lap data for each car.
        /// </summary>
        LapData[] lapData = new LapData[F1Globals.MAX_CARS];

        public LapDataPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            for (int i = 0; i < lapData.Length; i++)
            {
                lapData[i].Unpack(unpacker);
            }
        }
    }
}
