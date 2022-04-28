namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when the session has been flashed back by the player.
    /// </summary>
    internal class Flashback : EventDataDetails
    {
        /// <summary>
        /// Frame identifier that is being flashed back to.
        /// </summary>
        uint frameIdentifier;

        /// <summary>
        /// Session time that is being flashed back to.
        /// </summary>
        float sessionTime;

        public override void Unpack(Unpacker unpacker)
        {
            frameIdentifier = unpacker.NextUint();
            sessionTime = unpacker.NextFloat();
        }
    }
}
