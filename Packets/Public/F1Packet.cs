namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// All unpacked packets derive from this class.
    /// </summary>
    public abstract partial class F1Packet
    {
        /// <summary>
        /// Edition of the F1 game this packet is being sent by.
        /// </summary>
        public ushort PacketFormat { get { return header.packetFormat; } }

        /// <summary>
        /// Game major version (x.00).
        /// </summary>
        public byte GameMajorVersion { get { return header.gameMajorVersion; } }

        /// <summary>
        /// Game minor version (1.xx).
        /// </summary>
        public byte GameMinorVersion { get { return header.gameMinorVersion; } }

        /// <summary>
        /// Version of this packet type.
        /// </summary>
        public byte PacketVersion { get { return header.packetVersion; } }

        /// <summary>
        /// Identifier for this packet type. See documentation for information about each packet type.
        /// </summary>
        public PacketId PacketId { get { return header.packetId; } }

        /// <summary>
        /// Unique identifier for the session. Each session generates a new identifier.
        /// </summary>
        public ulong SessionUID { get { return header.sessionUID; } }

        /// <summary>
        /// Session timestamp in seconds.
        /// </summary>
        public float SessionTime { get { return header.sessionTime; } }

        /// <summary>
        /// Identifier for the frame the packet was retrieved on.
        /// </summary>
        public uint FrameIdentifier { get { return header.frameIdentifier; } }

        /// <summary>
        /// Index of the players car.
        /// </summary>
        public byte PlayerCarIndex { get { return header.playerCarIndex; } }

        /// <summary>
        /// Index of the secondary players car (splitscreen player). 255 if there is no secondary player.
        /// </summary>
        public byte SecondaryPlayerCarIndex { get { return header.secondaryPlayerCarIndex; } }
    }
}