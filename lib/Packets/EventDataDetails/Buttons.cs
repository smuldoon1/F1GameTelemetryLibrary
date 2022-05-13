namespace F1GameTelemetry
{
    /// <summary>
    /// Stores event details for when the player is pressing buttons.
    /// </summary>
    public class Buttons : EventDataDetails
    {
        /// <summary>
        /// Bit flags specifying which buttons are currently being pressed.
        /// </summary>
        public ButtonFlags ButtonStatus { get; }

        public Buttons(Unpacker unpacker)
        {
            ButtonStatus = (ButtonFlags)unpacker.NextUint();

            unpacker.Dump(4);
        }
    }
}
