using F1GameTelemetryLibrary.Packets.Enums;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Stores event details for when the start lights have changed.
    /// </summary>
    internal class StartLights : EventDataDetails
    {
        /// <summary>
        /// The number of lights that are lit.
        /// </summary>
        byte numberOfLights;

        public override void Unpack(Unpacker unpacker)
        {
            numberOfLights = unpacker.NextByte();
        }
    }
}
