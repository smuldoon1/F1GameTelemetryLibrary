namespace F1GameTelemetryLibrary.Statuses
{
    /// <summary>
    /// Car status packet stores status information for all cars.
    /// </summary>
    internal class CarStatusPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car statuses.
        /// </summary>
        CarStatusData[] carStatusData = new CarStatusData[F1Globals.MAX_CARS];

        public CarStatusPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            for (int i = 0; i < carStatusData.Length; i++)
            {
                carStatusData[i] = new CarStatusData();
                carStatusData[i].Unpack(unpacker);
            }

            unpacker.Finish();
        }
    }
}
