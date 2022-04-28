using F1GameTelemetryLibrary.Packets.Enums;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Stores event details for when a car is retiring.
    /// </summary>
    internal class Retirement : EventDataDetails
    {
        /// <summary>
        /// Vehicle index of the car that is retiring.
        /// </summary>
        byte vehicleIndex;

        public override void Unpack(Unpacker unpacker)
        {
            vehicleIndex = unpacker.NextByte();
        }
    }
}
