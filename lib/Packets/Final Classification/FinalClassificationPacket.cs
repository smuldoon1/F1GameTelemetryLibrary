namespace F1GameTelemetry
{
    /// <summary>
    /// Final classification packet stores details about the final classification at the end of a session.
    /// </summary>
    public partial class FinalClassificationPacket : F1Packet, IPacket
    {
        /// <summary>
        /// The number of cars in the final classification.
        /// </summary>
        public byte NumberOfCars { get { return numberOfCars; } }

        /// <summary>
        /// Array of final car classification data.
        /// </summary>
        public FinalClassificationData[] ClassificationData { get { return classificationData; } }
    }
}
