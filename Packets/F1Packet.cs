namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// All unpacked packets derive from this class.
    /// </summary>
    partial class F1Packet
    {
        /// <summary>
        /// Edition of the F1 game this packet is being sent by.
        /// </summary>
        ushort packetFormat;

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
        PacketId packetId;

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

        /// <summary>
        /// Wrapper for unpacking a UDP packet and returning a packet class depending on the packet type.
        /// </summary>
        /// <param name="udpPacket"></param>
        /// <returns></returns>
        /// <exception cref="InvalidPacketException"></exception>
        public F1Packet(byte[] udpPacket)
        {
            byte[] remainingData = Unpack(udpPacket);
            switch (packetId)
            {
                case PacketId.MOTION:
                    return new Motion.MotionPacket(remainingData);
                case PacketId.SESSION:
                    return new Sessions.SessionPacket(remainingData);
                case PacketId.LAP_DATA:
                    return new Laps.LapDataPacket(remainingData);
                case PacketId.EVENT:
                    return new Events.EventPacket(remainingData);
                case PacketId.PARTICIPANTS:
                    return new Participants.ParticipantsPacket(remainingData);
                case PacketId.CAR_SETUPS:
                    return new Setups.CarSetupsPacket(remainingData);
                case PacketId.CAR_TELEMETRY:
                    return new Telemetry.CarTelemetryPacket(remainingData);
                case PacketId.CAR_STATUS:
                    return new Statuses.CarStatusPacket(remainingData);
                case PacketId.FINAL_CLASSIFICATION:
                    return new Classifications.FinalClassificationPacket(remainingData);
                case PacketId.LOBBY_INFO:
                    return new Lobbies.LobbyInfoPacket(remainingData);
                case PacketId.CAR_DAMAGE:
                    return new Damage.CarDamagePacket(remainingData);
                case PacketId.SESSION_HISTORY:
                    return new SessionHistory.SessionHistoryPacket(remainingData);
            }
            throw new InvalidPacketException((byte)header.packetId);
        }

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