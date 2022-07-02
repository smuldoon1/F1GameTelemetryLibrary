namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Lap data packet gives details about the laps of all cars in the session.
    /// </summary>
    partial class LapDataPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of lap data for each car.
        /// </summary>
        LapData[] lapData = new LapData[F1Globals.MAX_CARS];

        /// <summary>
        /// Index of the Personal Best car in time trial.
        /// </summary>
        byte timeTrialPBVehicleIndex;

        /// <summary>
        /// Index of the Rival car in time trial.
        /// </summary>
        byte timeTrialRivalVehicleIndex;

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
                lapData[i] = new LapData();
                lapData[i].Unpack(unpacker);
            }
            timeTrialPBVehicleIndex = unpacker.NextByte();
            timeTrialRivalVehicleIndex = unpacker.NextByte();

            unpacker.Finish();
        }
    }
}
