namespace F1GameTelemetry
{
    /// <summary>
    /// Status information about a particular car.
    /// </summary>
    public partial class FinalClassificationData : IPacketStruct
    {
        /// <summary>
        /// Finishing position of the car.
        /// </summary>
        public byte Position { get { return position; } }

        /// <summary>
        /// Number of laps completed.
        /// </summary>
        public byte LapsCompleted { get { return lapsCompleted; } }

        /// <summary>
        /// Grid position of the car at the start of the race.
        /// </summary>
        public byte GridPosition { get { return gridPosition; } }

        /// <summary>
        /// Amount of points scored in the session.
        /// </summary>
        public byte Points { get { return points; } }

        /// <summary>
        /// Number of pit stops made in the session.
        /// </summary>
        public byte PitStops { get { return pitStops; } }

        /// <summary>
        /// Status of the car at the end of the session.
        /// </summary>
        public ResultStatus ResultStatus { get { return resultStatus; } }

        /// <summary>
        /// Fastest lap time of the session for this car.
        /// </summary>
        public uint BestLapTime { get { return bestLapTime; } }

        /// <summary>
        /// Total race time in seconds before penalties are applied.
        /// </summary>
        public double TotalRaceTime { get { return totalRaceTime; } }

        /// <summary>
        /// Total penalties accumulated in seconds.
        /// </summary>
        public byte PenaltyTime { get { return penaltyTime; } }

        /// <summary>
        /// Number of penalties accumulated by this driver.
        /// </summary>
        public byte PenaltyCount { get { return penaltyCount; } }

        /// <summary>
        /// Number of tyre stints this driver had.
        /// </summary>
        public byte TyreStintCount { get { return tyreStintCount; } }

        /// <summary>
        /// Actual tyres compounds used by this driver.
        /// </summary>
        public ActualTyreCompound[] TyreStints { get { return tyreStints; } }

        /// <summary>
        /// Visual tyre compounds used by this driver. Can be different from the actual tyre compounds.
        /// </summary>
        public VisualTyreCompound[] VisualTyreStints { get { return visualTyreStints; } }
    }
}
