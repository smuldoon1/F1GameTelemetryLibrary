using F1GameTelemetryLibrary.Enums;

namespace F1GameTelemetryLibrary.Sessions
{
    /// <summary>
    /// Data about a particlar marshall zone at the track.
    /// </summary>
    internal class MarshallZone : IPacketStruct
    {
        /// <summary>
        /// Distance through the lap the marshall zone starts represented as a fraction between 0 and 1.
        /// </summary>
        float zoneStart;

        /// <summary>
        /// The flag being waved at this marshall zone.
        /// </summary>
        Flag zoneFlag;

        void IPacketStruct.Unpack(Unpacker unpacker)
        {
            zoneStart = unpacker.NextByte();
            zoneFlag = (Flag)unpacker.NextSbyte();
        }
    }
}
