namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when the players teammate is pitting.
    /// </summary>
    internal class TeammateInPits : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of teammate.
        /// </summary>
        byte vehicleIndex;

        public override void Unpack(Unpacker unpacker)
        {
            vehicleIndex = unpacker.NextByte();
        }
    }
}
