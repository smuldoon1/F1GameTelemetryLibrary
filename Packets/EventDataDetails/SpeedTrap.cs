namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when a car has triggered the speed trap.
    /// </summary>
    internal class SpeedTrap : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that triggered the speed trap.
        /// </summary>
        byte vehicleIndex;

        /// <summary>
        /// Speed measured when triggering the speed trap.
        /// </summary>
        float speed;

        /// <summary>
        /// Is this the fastest recorded speed in the session overall?
        /// </summary>
        bool isOverallFastestInSession;

        /// <summary>
        /// Is this the fastest recorded speed for this driver in the session overall?
        /// </summary>
        bool isDriverFastestInSession;

        public override void Unpack(Unpacker unpacker)
        {
            vehicleIndex = unpacker.NextByte();
            speed = unpacker.NextFloat();
            isOverallFastestInSession = unpacker.NextBool();
            isDriverFastestInSession = unpacker.NextBool();
        }
    }
}
