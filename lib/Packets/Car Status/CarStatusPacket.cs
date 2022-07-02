namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Car status packet stores status information for all cars.
    /// </summary>
    public partial class CarStatusPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car statuses.
        /// </summary>
        public CarStatusData[] CarStatusData { get { return carStatusData; } }
    }
}
