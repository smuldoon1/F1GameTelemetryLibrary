namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Stores event details for when the start lights have changed.
    /// </summary>
    public class StartLights : EventDataDetails
    {
        /// <summary>
        /// The number of lights that are lit.
        /// </summary>
        public byte NumberOfLights { get; }

        public StartLights(Unpacker unpacker)
        {
            NumberOfLights = unpacker.NextByte();

            unpacker.Dump(11);
        }
    }
}
