using F1GameTelemetryLibrary.Packets.Enums;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Stores event details for when the player is pressing buttons.
    /// </summary>
    internal class Buttons : EventDataDetails
    {
        /// <summary>
        /// Bit flags specifying which buttons are currently being pressed.
        /// </summary>
        ButtonFlags buttonStatus;

        public override void Unpack(Unpacker unpacker)
        {
            buttonStatus = (ButtonFlags)unpacker.NextUint();
        }
    }
}
