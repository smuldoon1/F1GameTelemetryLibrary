namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when a car has won the race.
    /// </summary>
    internal class RaceWinner : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the race winner.
        /// </summary>
        byte vehicleIndex;

        public override void Unpack(Unpacker unpacker)
        {
            vehicleIndex = unpacker.NextByte();
        }
    }
}
