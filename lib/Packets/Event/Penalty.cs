namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Stores event details for when a car has been given a penalty.
    /// </summary>
    public class Penalty : EventDataDetails
    {
        /// <summary>
        /// The index of the type of penalty being given.
        /// </summary>
        public byte PenaltyType { get; }

        /// <summary>
        /// The index of the infringement type.
        /// </summary>
        public byte InfringementType { get; }

        /// <summary>
        /// Vehicle index of the offending car.
        /// </summary>
        public byte VehicleIndex { get; }

        /// <summary>
        /// Vehicle index of the other car involved if there is one.
        /// </summary>
        public byte OtherVehicleIndex { get; }

        /// <summary>
        /// Time gained or time spent infringing in seconds.
        /// </summary>
        public byte Time { get; }

        /// <summary>
        /// The lap number that the penalty occurred on.
        /// </summary>
        public byte LapNumber { get; }

        /// <summary>
        /// Number of places gained because of the infringement.
        /// </summary>
        public byte PlacesGained { get; }

        public Penalty(Unpacker unpacker)
        {
            PenaltyType = unpacker.NextByte();
            InfringementType = unpacker.NextByte();
            VehicleIndex = unpacker.NextByte();
            OtherVehicleIndex = unpacker.NextByte();
            Time = unpacker.NextByte();
            LapNumber = unpacker.NextByte();
            PlacesGained = unpacker.NextByte();

            unpacker.Dump(1);
        }
    }
}
