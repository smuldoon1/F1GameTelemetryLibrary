namespace F1GameTelemetry
{
    /// <summary>
    /// Stores event details for when a car is retiring.
    /// </summary>
    public class Retirement : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that is retiring.
        /// </summary>
        public byte VehicleIndex { get; }

        public Retirement(Unpacker unpacker)
        {
            VehicleIndex = unpacker.NextByte();

            unpacker.Dump(7);
        }
    }
}
