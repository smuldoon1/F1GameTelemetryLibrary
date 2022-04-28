using F1GameTelemetryLibrary.Enums;

namespace F1GameTelemetryLibrary.Classifications
{
    /// <summary>
    /// Status information about a particular car.
    /// </summary>
    internal struct FinalClassificationData : IPacketStruct
    {
        /// <summary>
        /// Finishing position of the car.
        /// </summary>
        byte position;

        /// <summary>
        /// Number of laps completed.
        /// </summary>
        byte lapsCompleted;

        /// <summary>
        /// Grid position of the car at the start of the race.
        /// </summary>
        byte gridPosition;

        /// <summary>
        /// Amount of points scored in the session.
        /// </summary>
        byte points;

        /// <summary>
        /// Number of pit stops made in the session.
        /// </summary>
        byte pitStops;

        /// <summary>
        /// Status of the car at the end of the session.
        /// </summary>
        ResultStatus resultStatus;

        /// <summary>
        /// Fastest lap time of the session for this car.
        /// </summary>
        uint bestLapTime;

        /// <summary>
        /// Total race time in seconds before penalties are applied.
        /// </summary>
        double totalRaceTime;

        /// <summary>
        /// Total penalties accumulated in seconds.
        /// </summary>
        byte penaltyTime;

        /// <summary>
        /// Number of penalties accumulated by this driver.
        /// </summary>
        byte penaltyCount;

        /// <summary>
        /// Number of tyre stints this driver had.
        /// </summary>
        byte tyreStintCount;

        /// <summary>
        /// Actual tyres compounds used by this driver.
        /// </summary>
        ActualTyreCompound[] tyreStints;

        /// <summary>
        /// Visual tyre compounds used by this driver. Can be different from the actual tyre compounds.
        /// </summary>
        VisualTyreCompound[] visualTyreStints;

        public FinalClassificationData()
        {
            position = 0;
            lapsCompleted = 0;
            gridPosition = 0;
            points = 0;
            pitStops = 0;
            resultStatus = 0;
            bestLapTime = 0;
            totalRaceTime = 0;
            penaltyTime = 0;
            penaltyCount = 0;
            tyreStintCount = 0;
            tyreStints = new ActualTyreCompound[F1Globals.MAX_TYRE_STINTS_HISTORY_DATA];
            visualTyreStints = new VisualTyreCompound[F1Globals.MAX_TYRE_STINTS_HISTORY_DATA];
        }

        public void Unpack(Unpacker unpacker)
        {
            position = unpacker.NextByte();
            lapsCompleted = unpacker.NextByte();
            gridPosition = unpacker.NextByte();
            points = unpacker.NextByte();
            pitStops = unpacker.NextByte();
            resultStatus = (ResultStatus)unpacker.NextByte();
            bestLapTime = unpacker.NextUint();
            totalRaceTime = unpacker.NextDouble();
            penaltyTime = unpacker.NextByte();
            penaltyCount = unpacker.NextByte();
            tyreStintCount = unpacker.NextByte();
            for (int i = 0; i < tyreStints.Length; i++)
            {
                tyreStints[i] = (ActualTyreCompound)unpacker.NextByte();
            }
            for (int i = 0; i < visualTyreStints.Length; i++)
            {
                visualTyreStints[i] = (VisualTyreCompound)unpacker.NextByte();
            }
        }
    }
}
