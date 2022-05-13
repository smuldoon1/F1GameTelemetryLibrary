namespace F1GameTelemetry
{
    /// <summary>
    /// Each packet has a header which should be unpacked first.
    /// </summary>
    public struct PacketHeader
    {
        /// <summary>
        /// Edition of the F1 game this packet is being sent by.
        /// </summary>
        internal ushort packetFormat;

        /// <summary>
        /// Game major version (x.00).
        /// </summary>
        internal byte gameMajorVersion;

        /// <summary>
        /// Game minor version (1.xx).
        /// </summary>
        internal byte gameMinorVersion;

        /// <summary>
        /// Version of this packet type.
        /// </summary>
        internal byte packetVersion;

        /// <summary>
        /// Identifier for this packet type. See documentation for information about each packet type.
        /// </summary>
        internal PacketId packetId;

        /// <summary>
        /// Unique identifier for the session. Each session generates a new identifier.
        /// </summary>
        internal ulong sessionUID;

        /// <summary>
        /// Session timestamp in seconds.
        /// </summary>
        internal float sessionTime;

        /// <summary>
        /// Identifier for the frame the packet was retrieved on.
        /// </summary>
        internal uint frameIdentifier;

        /// <summary>
        /// Index of the players car.
        /// </summary>
        internal byte playerCarIndex;

        /// <summary>
        /// Index of the secondary players car (splitscreen player). 255 if there is no secondary player.
        /// </summary>
        internal byte secondaryPlayerCarIndex;

        public byte[] Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            packetFormat = unpacker.NextUshort();
            gameMajorVersion = unpacker.NextByte();
            gameMinorVersion = unpacker.NextByte();
            packetVersion = unpacker.NextByte();
            packetId = (PacketId)unpacker.NextByte();
            sessionUID = unpacker.NextUlong();
            sessionTime = unpacker.NextFloat();
            frameIdentifier = unpacker.NextUint();
            playerCarIndex = unpacker.NextByte();
            secondaryPlayerCarIndex = unpacker.NextByte();

            return unpacker.RetrieveUnconvertedBytes();
        }
    }
}
