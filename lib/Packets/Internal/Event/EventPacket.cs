namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Event packet stores details about certain events that happen during a session.
    /// </summary>
    partial class EventPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Event code is used to determine what type of EventDataDetails should be stored.
        /// </summary>
        string eventCode = "";

        /// <summary>
        /// Stores details about the event that has occurred. This will be null if the event type does not have specific details to store.
        /// </summary>
        EventDataDetails? eventDataDetails;

        public EventPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            eventCode = unpacker.NextString(4);
            eventDataDetails = EventDataDetails.CreateEventDataDetails(eventCode, unpacker);

            unpacker.Finish();
        }
    }
}
