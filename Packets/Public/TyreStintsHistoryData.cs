using F1GameTelemetryLibrary.Enums;

namespace F1GameTelemetryLibrary.SessionHistory
{
    /// <summary>
    /// Stores historical data for each tyre stint done by a particular car.
    /// </summary>
    public partial class TyreStintsHistoryData : IPacketStruct
    {
        /// <summary>
        /// Lap that the tyre stint ends on. 255 if this is the current stint.
        /// </summary>
        public byte EndLap { get { return endLap; } }

        /// <summary>
        /// The actual tyre compound that is used in this stint.
        /// </summary>
        public ActualTyreCompound TyreCompound { get { return tyreCompound; } }

        /// <summary>
        /// The tyre compound that appears to be on the car this stint. Can be different from the actual tyre compound.
        /// </summary>
        public VisualTyreCompound VisualTyreCompound { get { return visualTyreCompound; } }
    }
}
