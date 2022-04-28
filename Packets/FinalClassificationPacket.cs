using F1GameTelemetryLibrary.Packets;
using F1GameTelemetryLibrary.Packets.Enums;
using F1GameTelemetryLibrary.Packets.Structs;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Final classification packet stores details about the final classification at the end of a session.
    /// </summary>
    internal class FinalClassificationPacket : F1Packet, IPacket
    {
        /// <summary>
        /// The number of cars in the final classification.
        /// </summary>
        byte numberOfCars;

        /// <summary>
        /// Array of final car classification data.
        /// </summary>
        LapData[] classificationData = new LapData[F1Globals.MAX_CARS];

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
                classificationData[i].Unpack(unpacker);
            }
        }
    }
}
