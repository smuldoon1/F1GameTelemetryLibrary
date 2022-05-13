namespace F1GameTelemetry
{
    /// <summary>
    /// Car setups packet stores the car setups for each vehicle in the session. In network games only the players car and AI cars will have data.
    /// </summary>
    public partial class CarTelemetryPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car telemetry data.
        /// </summary>
        public CarTelemetryData[] CarTelemetryData { get { return carTelemetryData; } }

        /// <summary>
        /// Index of the multi-functional display panel that is open. The index of each panel depends on the current game mode.
        /// </summary>
        public byte MfdPanelIndex { get { return mfdPanelIndex; } }

        /// <summary>
        /// Index of the multi-functional display panel that is open for the secondary player. The index of each panel depends on the current game mode.
        /// </summary>
        public byte MfdPanelIndexSecondaryPlayer { get { return mfdPanelIndexSecondaryPlayer; } }

        /// <summary>
        /// Gear that the game suggests the player should be in.
        /// </summary>
        public sbyte SuggestedGear { get { return suggestedGear; } }
    }
}
