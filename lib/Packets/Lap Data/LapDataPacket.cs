namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Lap data packet gives details about the laps of all cars in the session.
    /// </summary>
    public partial class LapDataPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of lap data for each car.
        /// </summary>
        public LapData[] LapData { get { return lapData; } }
    }
}
