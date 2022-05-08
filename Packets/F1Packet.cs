namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// All unpacked packets derive from this class.
    /// </summary>
    public abstract class F1Packet
    {
        /// <summary>
        /// Struct that stores header values of every UDP packet that is sent.
        /// </summary>
        internal PacketHeader header;

        public byte PlayerCar { get { return header.playerCarIndex; } }

        public float SessionTime { get { return header.sessionTime; } }

        public static F1Packet CreatePacket(byte[] udpPacket)
        {
            PacketHeader header = new PacketHeader();
            byte[] remainingData = header.Unpack(udpPacket);
            switch (header.packetId)
            {
                case 0:
                    return new Motion.MotionPacket(header, remainingData);
                case 1: // 63 cant be converted into type bool
                    return new Sessions.SessionPacket(header, remainingData);
                case 2:
                    return new Laps.LapDataPacket(header, remainingData);
                case 3: // Event code strings are corrupted
                    return new Events.EventPacket(header, remainingData);
                case 4:
                    return new Participants.ParticipantsPacket(header, remainingData);
                case 5:
                    return new Setups.CarSetupsPacket(header, remainingData);
                case 6:
                    return new Telemetry.CarTelemetryPacket(header, remainingData);
                case 7:
                    return new Statuses.CarStatusPacket(header, remainingData);
                case 8:
                    return new Classifications.FinalClassificationPacket(header, remainingData);
                case 9:
                    return new Lobbies.LobbyInfoPacket(header, remainingData);
                case 10:
                    return new Damage.CarDamagePacket(header, remainingData);
                case 11:
                    return new SessionHistory.SessionHistoryPacket(header, remainingData);
            }
            throw new InvalidPacketException(header.packetId);
        }
    }
}