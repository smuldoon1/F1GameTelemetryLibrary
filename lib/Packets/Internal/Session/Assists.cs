namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Used to store assist data.
    /// </summary>
    partial class Assists : IPacketStruct
    {
        /// <summary>
        /// Is steering assist enabled?
        /// </summary>
        bool steeringAssist;

        /// <summary>
        /// Braking assist mode.
        /// </summary>
        BrakingAssistMode brakingAssist;

        /// <summary>
        /// Gearbox assist mode.
        /// </summary>
        GearboxAssistMode gearboxAssist;

        /// <summary>
        /// Is pit assist enabled?
        /// </summary>
        bool pitAssist;

        /// <summary>
        /// Is pit release assist enabled?
        /// </summary>
        bool pitReleaseAssist;

        /// <summary>
        /// Is ERS assist enabled?
        /// </summary>
        bool ersAssist;

        /// <summary>
        /// Is DRS assist enabled?
        /// </summary>
        bool drsAssist;

        /// <summary>
        /// Dynamic racing line assist mode.
        /// </summary>
        RacingLineAssistMode dynamicRacingLine;

        /// <summary>
        /// Is the dynamic racing line set to 3D?
        /// </summary>
        bool isDynamicRacingLine3D;

        public void Unpack(Unpacker unpacker)
        {
            steeringAssist = unpacker.NextBool();
            brakingAssist = (BrakingAssistMode)unpacker.NextByte();
            gearboxAssist = (GearboxAssistMode)unpacker.NextByte();
            pitAssist = unpacker.NextBool();
            pitReleaseAssist = unpacker.NextBool();
            ersAssist = unpacker.NextBool();
            drsAssist = unpacker.NextBool();
            dynamicRacingLine = (RacingLineAssistMode)unpacker.NextByte();
            isDynamicRacingLine3D = unpacker.NextBool();
        }
    }
}
