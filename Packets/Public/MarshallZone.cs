using F1GameTelemetryLibrary.Enums;

namespace F1GameTelemetryLibrary.Sessions
{
    /// <summary>
    /// Data about a particlar marshall zone at the track.
    /// </summary>
    public partial class MarshallZone : IPacketStruct
    {
        /// <summary>
        /// Distance through the lap the marshall zone starts represented as a fraction between 0 and 1.
        /// </summary>
        public float ZoneStart { get { return zoneStart; } }

        /// <summary>
        /// The flag being waved at this marshall zone.
        /// </summary>
        public Flag ZoneFlag { get { return zoneFlag; } }
    }
}
