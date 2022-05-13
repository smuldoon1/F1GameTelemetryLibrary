namespace F1GameTelemetry
{
    /// <summary>
    /// All unpacked packets derive from this class.
    /// </summary>
    partial class F1Packet
    {
        /// <summary>
        /// Struct that stores header values of every UDP packet that is sent.
        /// </summary>
        internal PacketHeader header;

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
            switch (header.packetId)
            {
                case PacketId.MOTION:
                    return new MotionPacket(header, remainingData);
                case PacketId.SESSION:
                    return new SessionPacket(header, remainingData);
                case PacketId.LAP_DATA:
                    return new LapDataPacket(header, remainingData);
                case PacketId.EVENT:
                    return new EventPacket(header, remainingData);
                case PacketId.PARTICIPANTS:
                    return new ParticipantsPacket(header, remainingData);
                case PacketId.CAR_SETUPS:
                    return new CarSetupsPacket(header, remainingData);
                case PacketId.CAR_TELEMETRY:
                    return new CarTelemetryPacket(header, remainingData);
                case PacketId.CAR_STATUS:
                    return new CarStatusPacket(header, remainingData);
                case PacketId.FINAL_CLASSIFICATION:
                    return new FinalClassificationPacket(header, remainingData);
                case PacketId.LOBBY_INFO:
                    return new LobbyInfoPacket(header, remainingData);
                case PacketId.CAR_DAMAGE:
                    return new CarDamagePacket(header, remainingData);
                case PacketId.SESSION_HISTORY:
                    return new SessionHistoryPacket(header, remainingData);
            }
            throw new InvalidPacketException((byte)header.packetId);
        }
    }
}