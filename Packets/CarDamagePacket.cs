using F1GameTelemetryLibrary.Packets;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Car damage packet stores damage and wear data for cars in the session.
    /// </summary>
    internal class CarDamagePacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car damage data.
        /// </summary>
        CarDamageData[] carDamageData = new CarDamageData[F1Globals.MAX_CARS];

        public CarDamagePacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            for (int i = 0; i < carDamageData.Length; i++)
            {
                carDamageData[i].Unpack(unpacker);
            }
        }
    }
}
