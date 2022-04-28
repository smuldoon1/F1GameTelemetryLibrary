namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when a car has been given a penalty.
    /// </summary>
    internal class Penalty : EventDataDetails
    {
        /// <summary>
        /// The index of the type of penalty being given.
        /// </summary>
        byte penaltyType;

        /// <summary>
        /// The index of the infringement type.
        /// </summary>
        byte infringementType;

        /// <summary>
        /// Vehicle index of the offending car.
        /// </summary>
        byte vehicleIndex;

        /// <summary>
        /// Vehicle index of the other car involved if there is one.
        /// </summary>
        byte otherVehicleIndex;

        /// <summary>
        /// Time gained or time spent infringing in seconds.
        /// </summary>
        byte time;

        /// <summary>
        /// The lap number that the penalty occurred on.
        /// </summary>
        byte lapNumber;

        /// <summary>
        /// Number of places gained because of the infringement.
        /// </summary>
        byte placesGained;

        public override void Unpack(Unpacker unpacker)
        {
            penaltyType = unpacker.NextByte();
            infringementType = unpacker.NextByte();
            vehicleIndex = unpacker.NextByte();
            otherVehicleIndex = unpacker.NextByte();
            time = unpacker.NextByte();
            lapNumber = unpacker.NextByte();
            placesGained = unpacker.NextByte();
        }
    }
}
