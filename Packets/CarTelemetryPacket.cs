namespace F1GameTelemetryLibrary.Telemetry
{
    /// <summary>
    /// Car setups packet stores the car setups for each vehicle in the session. In network games only the players car and AI cars will have data.
    /// </summary>
    internal class CarTelemetryPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car telemetry data.
        /// </summary>
        CarTelemetryData[] carTelemetryData = new CarTelemetryData[F1Globals.MAX_CARS];

        /// <summary>
        /// Index of the multi-functional display panel that is open. The index of each panel depends on the current game mode.
        /// </summary>
        byte mfdPanelIndex;

        /// <summary>
        /// Index of the multi-functional display panel that is open for the secondary player. The index of each panel depends on the current game mode.
        /// </summary>
        byte mfdPanelIndexSecondaryPlayer;

        /// <summary>
        /// Gear that the game suggests the player should be in.
        /// </summary>
        sbyte suggestedGear;

        public CarTelemetryPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            for (int i = 0; i < carTelemetryData.Length; i++)
            {
                carTelemetryData[i].Unpack(unpacker);
            }
            mfdPanelIndex = unpacker.NextByte();
            mfdPanelIndexSecondaryPlayer = unpacker.NextByte();
            suggestedGear = unpacker.NextSbyte();
        }
    }
}
