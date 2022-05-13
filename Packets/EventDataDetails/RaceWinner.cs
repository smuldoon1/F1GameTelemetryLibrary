namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when a car has won the race.
    /// </summary>
    public class RaceWinner : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the race winner.
        /// </summary>
        public byte VehicleIndex { get; }

        public RaceWinner(Unpacker unpacker)
        {
            VehicleIndex = unpacker.NextByte();

            unpacker.Dump(7);
        }
    }
}
