namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when a car has served a drive through penalty.
    /// </summary>
    public class DriveThroughPenaltyServed : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that has served the drive through penalty.
        /// </summary>
        public byte VehicleIndex { get; }

        public DriveThroughPenaltyServed(Unpacker unpacker)
        {
            VehicleIndex = unpacker.NextByte();

            unpacker.Dump(7);
        }
    }
}
