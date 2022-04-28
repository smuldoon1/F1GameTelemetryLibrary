namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when a car has served a drive through penalty.
    /// </summary>
    internal class DriveThroughPenaltyServed : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that has served the drive through penalty.
        /// </summary>
        byte vehicleIndex;

        public override void Unpack(Unpacker unpacker)
        {
            vehicleIndex = unpacker.NextByte();
        }
    }
}
