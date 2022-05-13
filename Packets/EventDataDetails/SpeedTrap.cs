namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when a car has triggered the speed trap.
    /// </summary>
    public class SpeedTrap : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that triggered the speed trap.
        /// </summary>
        public byte VehicleIndex { get; }

        /// <summary>
        /// Speed measured when triggering the speed trap.
        /// </summary>
        public float Speed { get; }

        /// <summary>
        /// Is this the fastest recorded speed in the session overall?
        /// </summary>
        public bool IsOverallFastestInSession { get; }

        /// <summary>
        /// Is this the fastest recorded speed for this driver in the session overall?
        /// </summary>
        public bool IsDriverFastestInSession { get; }

        public SpeedTrap(Unpacker unpacker)
        {
            VehicleIndex = unpacker.NextByte();
            Speed = unpacker.NextFloat();
            IsOverallFastestInSession = unpacker.NextBool();
            IsDriverFastestInSession = unpacker.NextBool();

            unpacker.Dump(1);
        }
    }
}
