namespace F1GameTelemetry
{
    /// <summary>
    /// Used to store assist data.
    /// </summary>
    public partial class Assists : IPacketStruct
    {
        /// <summary>
        /// Is steering assist enabled?
        /// </summary>
        public bool SteeringAssist { get { return steeringAssist; } }

        /// <summary>
        /// Braking assist mode.
        /// </summary>
        public BrakingAssistMode BrakingAssist { get { return brakingAssist; } }

        /// <summary>
        /// Gearbox assist mode.
        /// </summary>
        public GearboxAssistMode GearboxAssist { get { return gearboxAssist; } }

        /// <summary>
        /// Is pit assist enabled?
        /// </summary>
        public bool PitAssist { get { return pitAssist; } }

        /// <summary>
        /// Is pit release assist enabled?
        /// </summary>
        public bool PitReleaseAssist { get { return pitReleaseAssist; } }

        /// <summary>
        /// Is ERS assist enabled?
        /// </summary>
        public bool ERSAssist { get { return ersAssist; } }

        /// <summary>
        /// Is DRS assist enabled?
        /// </summary>
        public bool DRSAssist { get { return drsAssist; } }

        /// <summary>
        /// Dynamic racing line assist mode.
        /// </summary>
        public RacingLineAssistMode DynamicRacingLine { get { return dynamicRacingLine; } }

        /// <summary>
        /// Is the dynamic racing line set to 3D?
        /// </summary>
        public bool IsDynamicRacingLine3D { get { return isDynamicRacingLine3D; } }
    }
}
