namespace F1GameTelemetry_2021
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

        /// <summary>
        /// Vehicle index of the car in the session with the fastest speed trap speed.
        /// </summary>
        public byte FastestVehicleIndexInSession { get; }

        /// <summary>
        /// Speed of the fastest speed trap in the session.
        /// </summary>
        public float FastestSpeedInSession { get; }

        public SpeedTrap(Unpacker unpacker)
        {
            VehicleIndex = unpacker.NextByte();
            Speed = unpacker.NextFloat();
            IsOverallFastestInSession = unpacker.NextBool();
            IsDriverFastestInSession = unpacker.NextBool();
            FastestVehicleIndexInSession = unpacker.NextByte();
            FastestSpeedInSession = unpacker.NextFloat();

            unpacker.Finish();
        }
    }
}
