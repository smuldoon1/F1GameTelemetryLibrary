namespace F1GameTelemetryLibrary.Participants
{
    /// <summary>
    /// Partipants data packet stores data about all participants in the session.
    /// </summary>
    internal class ParticipantsPacket : F1Packet, IPacket
    {
        /// <summary>
        /// The number of active cars in the session.
        /// </summary>
        byte activeCars;

        /// <summary>
        /// Array of participants in the session.
        /// </summary>
        ParticipantData[] participants = new ParticipantData[F1Globals.MAX_CARS];

        public ParticipantsPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);
            activeCars = unpacker.NextByte();
            for (int i = 0; i < participants.Length; i++)
            {
                participants[i].Unpack(unpacker);
            }
        }
    }
}
