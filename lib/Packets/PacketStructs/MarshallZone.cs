namespace F1GameTelemetry
{
    /// <summary>
    /// Data about a particlar marshall zone at the track.
    /// </summary>
    partial class MarshallZone : IPacketStruct
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
            zoneStart = unpacker.NextFloat();
            zoneFlag = (Flag)unpacker.NextSbyte();
        }
    }
}
