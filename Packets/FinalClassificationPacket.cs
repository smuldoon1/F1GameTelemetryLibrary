namespace F1GameTelemetryLibrary.Classifications
{
    /// <summary>
    /// Final classification packet stores details about the final classification at the end of a session.
    /// </summary>
    partial class FinalClassificationPacket : F1Packet, IPacket
    {
        /// <summary>
        /// The number of cars in the final classification.
        /// </summary>
        byte numberOfCars;

        /// <summary>
        /// Array of final car classification data.
        /// </summary>
        FinalClassificationData[] classificationData = new FinalClassificationData[F1Globals.MAX_CARS];

        public FinalClassificationPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            numberOfCars = unpacker.NextByte();
            for (int i = 0; i < classificationData.Length; i++)
            {
                classificationData[i] = new FinalClassificationData();
                classificationData[i].Unpack(unpacker);
            }

            unpacker.Finish();
        }
    }
}
