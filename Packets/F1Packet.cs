namespace F1GameTelemetryLibrary
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