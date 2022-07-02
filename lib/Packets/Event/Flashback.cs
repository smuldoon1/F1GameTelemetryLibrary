namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Stores event details for when the session has been flashed back by the player.
    /// </summary>
    public class Flashback : EventDataDetails
    {
        /// <summary>
        /// Frame identifier that is being flashed back to.
        /// </summary>
        public uint FrameIdentifier { get; }

        /// <summary>
        /// Session time that is being flashed back to.
        /// </summary>
        public float SessionTime { get; }

        public Flashback(Unpacker unpacker)
        {
            FrameIdentifier = unpacker.NextUint();
            SessionTime = unpacker.NextFloat();

            unpacker.Finish();
        }
    }
}
