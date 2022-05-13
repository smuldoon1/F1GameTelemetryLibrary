namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Stores event details for when the player is pressing buttons.
    /// </summary>
    public class Buttons : EventDataDetails
    {
        /// <summary>
        /// Bit flags specifying which buttons are currently being pressed.
        /// </summary>
        public Enums.ButtonFlags ButtonStatus { get; }

        public Buttons(Unpacker unpacker)
        {
            ButtonStatus = (Enums.ButtonFlags)unpacker.NextUint();

            unpacker.Dump(4);
        }
    }
}
