namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Car setups packet stores the car setups for each vehicle in the session. In network games only the players car and AI cars will have data.
    /// </summary>
    partial class CarSetupsPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car setups.
        /// </summary>
        CarSetupData[] carSetups = new CarSetupData[F1Globals.MAX_CARS];

        public CarSetupsPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            for (int i = 0; i < carSetups.Length; i++)
            {
                carSetups[i] = new CarSetupData();
                carSetups[i].Unpack(unpacker);
            }

            unpacker.Finish();
        }
    }
}
