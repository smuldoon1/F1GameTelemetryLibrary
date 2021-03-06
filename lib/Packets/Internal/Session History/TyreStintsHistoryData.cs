namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Stores historical data for each tyre stint done by a particular car.
    /// </summary>
    partial class TyreStintsHistoryData : IPacketStruct
    {
        /// <summary>
        /// Lap that the tyre stint ends on. 255 if this is the current stint.
        /// </summary>
        byte endLap;

        /// <summary>
        /// The actual tyre compound that is used in this stint.
        /// </summary>
        ActualTyreCompound tyreCompound;

        /// <summary>
        /// The tyre compound that appears to be on the car this stint. Can be different from the actual tyre compound.
        /// </summary>
        VisualTyreCompound visualTyreCompound;

        public void Unpack(Unpacker unpacker)
        {
            endLap = unpacker.NextByte();
            tyreCompound = (ActualTyreCompound)unpacker.NextByte();
            visualTyreCompound = (VisualTyreCompound)unpacker.NextByte();
        }
    }
}
