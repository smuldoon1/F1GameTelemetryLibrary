using F1GameTelemetryLibrary.Packets;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// All unpacked packets derive from this class.
    /// </summary>
    internal abstract class F1Packet
    {
        /// <summary>
        /// Struct that stores header values of every UDP packet that is sent.
        /// </summary>
        internal PacketHeader header;

        public static F1Packet CreatePacket(byte[] udpPacket)
        {
            PacketHeader header = new PacketHeader();
            byte[] remainingData = header.Unpack(udpPacket);
            switch (header.packetId)
            {
                case 0:
                    return new MotionPacket(header, remainingData);
                case 1:
                    return new SessionPacket(header, remainingData);
                case 2:
                    return new LapDataPacket(header, remainingData);
                case 3:
                    return new EventPacket(header, remainingData);
                case 4:
                    return new ParticipantsPacket(header, remainingData);
                case 5:
                    return new CarSetupsPacket(header, remainingData);
                case 6:
                    return new CarTelemetryPacket(header, remainingData);
                case 7:
                    return new CarStatusPacket(header, remainingData);
                case 8:
                    return new FinalClassificationPacket(header, remainingData);
                case 9:
                    return new LobbyInfoPacket(header, remainingData);
                case 10:
                    return new CarDamagePacket(header, remainingData);
                case 11:
                    return new SessionHistoryPacket(header, remainingData);
            }
            throw new InvalidPacketException(header.packetId);
        }
    }
}