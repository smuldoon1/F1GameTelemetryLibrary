namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Event packet stores details about certain events that happen during a session.
    /// </summary>
    public partial class EventPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Event code is used to determine what type of EventDataDetails should be stored.
        /// </summary>
        public string EventCode { get { return eventCode; } }

        /// <summary>
        /// Stores details about the event that has occurred. This will be null if the event type does not have specific details to store.
        /// </summary>
        public EventDataDetails? EventDataDetails { get { return eventDataDetails; } }
    }
}
