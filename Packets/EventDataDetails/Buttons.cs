namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when the player is pressing buttons.
    /// </summary>
    internal class Buttons : EventDataDetails
    {
        /// <summary>
        /// Bit flags specifying which buttons are currently being pressed.
        /// </summary>
        Enums.ButtonFlags buttonStatus;

        public override void Unpack(Unpacker unpacker)
        {
            buttonStatus = (Enums.ButtonFlags)unpacker.NextUint();

            unpacker.Dump(4);
        }
    }
}
