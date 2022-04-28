namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Each packet has a header which should be unpacked first.
    /// </summary>
    internal struct PacketHeader
    {
        /// <summary>
        /// Edition of the F1 game this packet is being sent by.
        /// </summary>
        ulong packetFormat;

        /// <summary>
        /// Game major version (x.00).
        /// </summary>
        byte gameMajorVersion;

        /// <summary>
        /// Game minor version (1.xx).
        /// </summary>
        byte gameMinorVersion;

        /// <summary>
        /// Version of this packet type.
        /// </summary>
        byte packetVersion;

        /// <summary>
        /// Identifier for this packet type. See documentation for information about each packet type.
        /// </summary>
        internal byte packetId;

        /// <summary>
        /// Unique identifier for the session. Each session generates a new identifier.
        /// </summary>
        ulong sessionUID;

        /// <summary>
        /// Session timestamp in seconds.
        /// </summary>
        float sessionTime;

        /// <summary>
        /// Identifier for the frame the packet was retrieved on.
        /// </summary>
        uint frameIdentifier;

        /// <summary>
        /// Index of the players car.
        /// </summary>
        byte playerCarIndex;

        /// <summary>
        /// Index of the secondary players car (splitscreen player). 255 if there is no secondary player.
        /// </summary>
        byte secondaryPlayerCarIndex;

        public byte[] Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            packetFormat = unpacker.NextUlong();
            gameMajorVersion = unpacker.NextByte();
            gameMinorVersion = unpacker.NextByte();
            packetVersion = unpacker.NextByte();
            packetId = unpacker.NextByte();
            sessionUID = unpacker.NextUlong();
            sessionTime = unpacker.NextFloat();
            frameIdentifier = unpacker.NextUint();
            playerCarIndex = unpacker.NextByte();
            secondaryPlayerCarIndex = unpacker.NextByte();

            return unpacker.RetrieveUnconvertedBytes();
        }
    }
}
