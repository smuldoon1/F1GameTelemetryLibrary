namespace F1GameTelemetry
{
    /// <summary>
    /// Car setups packet stores the car setups for each vehicle in the session. In network games only the players car and AI cars will have data.
    /// </summary>
    public partial class CarSetupsPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car setups.
        /// </summary>
        public CarSetupData[] CarSetups { get { return carSetups; } }
    }
}
