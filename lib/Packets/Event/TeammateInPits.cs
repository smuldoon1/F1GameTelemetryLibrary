namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Stores event details for when the players teammate is pitting.
    /// </summary>
    public class TeammateInPits : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of teammate.
        /// </summary>
        public byte VehicleIndex { get; }

        public TeammateInPits(Unpacker unpacker)
        {
            VehicleIndex = unpacker.NextByte();

            unpacker.Dump(11);
        }
    }
}
