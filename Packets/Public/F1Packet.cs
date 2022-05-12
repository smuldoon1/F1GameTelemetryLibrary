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
        public ushort PacketFormat { get { return packetFormat; } }

        /// <summary>
        /// Game major version (x.00).
        /// </summary>
        public byte GameMajorVersion { get { return gameMajorVersion; } }

        /// <summary>
        /// Game minor version (1.xx).
        /// </summary>
        public byte GameMinorVersion { get { return gameMinorVersion; } }

        /// <summary>
        /// Version of this packet type.
        /// </summary>
        public byte PacketVersion { get { return packetVersion; } }

        /// <summary>
        /// Identifier for this packet type. See documentation for information about each packet type.
        /// </summary>
        public PacketId PacketId { get { return packetId; } }

        /// <summary>
        /// Unique identifier for the session. Each session generates a new identifier.
        /// </summary>
        public ulong SessionUID { get { return sessionUID; } }

        /// <summary>
        /// Session timestamp in seconds.
        /// </summary>
        public float SessionTime { get { return sessionTime; } }

        /// <summary>
        /// Identifier for the frame the packet was retrieved on.
        /// </summary>
        public uint FrameIdentifier { get { return frameIdentifier; } }

        /// <summary>
        /// Index of the players car.
        /// </summary>
        public byte PlayerCarIndex { get { return playerCarIndex; } }

        /// <summary>
        /// Index of the secondary players car (splitscreen player). 255 if there is no secondary player.
        /// </summary>
        public byte SecondaryPlayerCarIndex { get { return secondaryPlayerCarIndex; } }

        /// <summary>
        /// Wrapper for unpacking a UDP packet and returning a packet class depending on the packet type.
        /// </summary>
        /// <param name="udpPacket"></param>
        /// <returns></returns>
        /// <exception cref="InvalidPacketException"></exception>
        public static F1Packet CreatePacket(byte[] udpPacket)
        {
            PacketHeader header = new PacketHeader();
            byte[] remainingData = header.Unpack(udpPacket);
            switch (header)
            {
                case PacketId.MOTION:
                    return new Motion.MotionPacket(header, remainingData);
                case PacketId.SESSION:
                    return new Sessions.SessionPacket(header, remainingData);
                case PacketId.LAP_DATA:
                    return new Laps.LapDataPacket(header, remainingData);
                case PacketId.EVENT:
                    return new Events.EventPacket(header, remainingData);
                case PacketId.PARTICIPANTS:
                    return new Participants.ParticipantsPacket(header, remainingData);
                case PacketId.CAR_SETUPS:
                    return new Setups.CarSetupsPacket(header, remainingData);
                case PacketId.CAR_TELEMETRY:
                    return new Telemetry.CarTelemetryPacket(header, remainingData);
                case PacketId.CAR_STATUS:
                    return new Statuses.CarStatusPacket(header, remainingData);
                case PacketId.FINAL_CLASSIFICATION:
                    return new Classifications.FinalClassificationPacket(header, remainingData);
                case PacketId.LOBBY_INFO:
                    return new Lobbies.LobbyInfoPacket(header, remainingData);
                case PacketId.CAR_DAMAGE:
                    return new Damage.CarDamagePacket(header, remainingData);
                case PacketId.SESSION_HISTORY:
                    return new SessionHistory.SessionHistoryPacket(header, remainingData);
            }
            throw new InvalidPacketException((byte)header.packetId);
        }
    }
}