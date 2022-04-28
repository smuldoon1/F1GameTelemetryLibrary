using F1GameTelemetryLibrary.Packets.Enums;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Stores event details for when a car has served a stop go penalty.
    /// </summary>
    internal class StopGoPenaltyServed : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that has served the stop go penalty.
        /// </summary>
        byte vehicleIndex;

        public override void Unpack(Unpacker unpacker)
        {
            vehicleIndex = unpacker.NextByte();
        }
    }
}
