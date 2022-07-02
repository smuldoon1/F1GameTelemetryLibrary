namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Stores event details for when a new fastest lap is set.
    /// </summary>
    public class FastestLap : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that set the fastest lap.
        /// </summary>
        public byte VehicleIndex { get; }

        /// <summary>
        /// The lap time of the fastest lap in milliseconds.
        /// </summary>
        public float LapTime { get; }

        public FastestLap(Unpacker unpacker)
        {
            VehicleIndex = unpacker.NextByte();
            LapTime = unpacker.NextFloat();

            unpacker.Dump(7);
        }
    }
}
