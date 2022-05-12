namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// All unpacked packets derive from this class.
    /// </summary>
    public abstract partial class F1Packet
    {
        /// <summary>
        /// Struct that stores header values of every UDP packet that is sent.
        /// </summary>
        public PacketHeader Header { get { return header; } }
    }
}