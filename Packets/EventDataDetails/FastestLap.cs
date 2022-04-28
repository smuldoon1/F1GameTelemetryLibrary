namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when a new fastest lap is set.
    /// </summary>
    internal class FastestLap : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that set the fastest lap.
        /// </summary>
        byte vehicleIndex;

        /// <summary>
        /// The lap time of the fastest lap in milliseconds.
        /// </summary>
        float lapTime;

        public override void Unpack(Unpacker unpacker)
        {
            vehicleIndex = unpacker.NextByte();
            lapTime = unpacker.NextFloat();
        }
    }
}
