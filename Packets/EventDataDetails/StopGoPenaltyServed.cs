namespace F1GameTelemetry
{
    /// <summary>
    /// Stores event details for when a car has served a stop go penalty.
    /// </summary>
    public class StopGoPenaltyServed : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that has served the stop go penalty.
        /// </summary>
        public byte VehicleIndex { get; }

        public StopGoPenaltyServed(Unpacker unpacker)
        {
            VehicleIndex = unpacker.NextByte();

            unpacker.Dump(7);
        }
    }
}
