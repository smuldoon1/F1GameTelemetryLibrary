using F1GameTelemetryLibrary.Packets.Enums;

namespace F1GameTelemetryLibrary.Packets.Structs
{
    /// <summary>
    /// Data about a particlar marshall zone at the track.
    /// </summary>
    internal struct MarshallZone : IPacketStruct
    {
        /// <summary>
        /// Distance through the lap the marshall zone starts represented as a fraction between 0 and 1.
        /// </summary>
        float zoneStart;

        /// <summary>
        /// The flag being waved at this marshall zone.
        /// </summary>
        Flag zoneFlag;

        public void Unpack(Unpacker unpacker)
        {
            zoneStart = unpacker.NextByte();
            zoneFlag = (Flag)unpacker.NextSbyte();
        }
    }
}
