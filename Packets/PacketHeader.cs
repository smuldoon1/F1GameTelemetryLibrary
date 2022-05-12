namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Each packet has a header which should be unpacked first.
    /// </summary>
    public struct PacketHeader
    {
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
