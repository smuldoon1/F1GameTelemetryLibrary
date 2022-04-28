using F1GameTelemetryLibrary.Packets;
using F1GameTelemetryLibrary.Packets.Structs;

namespace F1GameTelemetryLibrary
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

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            for (int i = 0; i < carStatusData.Length; i++)
            {
                carStatusData[i].Unpack(unpacker);
            }
        }
    }
}
