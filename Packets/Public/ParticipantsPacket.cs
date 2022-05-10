namespace F1GameTelemetryLibrary.Participants
{
    /// <summary>
    /// Partipants data packet stores data about all participants in the session.
    /// </summary>
    public partial class ParticipantsPacket : F1Packet, IPacket
    {
        /// <summary>
        /// The number of active cars in the session.
        /// </summary>
        public byte ActiveCars { get { return activeCars; } }

        /// <summary>
        /// Array of participants in the session.
        /// </summary>
        public ParticipantData[] Participants { get { return participants; } }
    }
}
