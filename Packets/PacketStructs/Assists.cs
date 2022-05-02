namespace F1GameTelemetryLibrary.Sessions
{
    /// <summary>
    /// Used to store assist data.
    /// </summary>
    internal class Assists : IPacketStruct
    {
        /// <summary>
        /// Is steering assist enabled?
        /// </summary>
        bool steeringAssist;

        /// <summary>
        /// Braking assist mode.
        /// </summary>
        Enums.BrakingAssistMode brakingAssist;

        /// <summary>
        /// Gearbox assist mode.
        /// </summary>
        Enums.GearboxAssistMode gearboxAssist;

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
        bool ERSAssist;

        /// <summary>
        /// Is DRS assist enabled?
        /// </summary>
        bool DRSAssist;

        /// <summary>
        /// Dynamic racing line assist mode.
        /// </summary>
        Enums.RacingLineAssistMode dynamicRacingLine;

        /// <summary>
        /// Is the dynamic racing line set to 3D?
        /// </summary>
        bool isDynamicRacingLine3D;

        void IPacketStruct.Unpack(Unpacker unpacker)
        {
            steeringAssist = unpacker.NextBool();
            brakingAssist = (Enums.BrakingAssistMode)unpacker.NextByte();
            gearboxAssist = (Enums.GearboxAssistMode)unpacker.NextByte();
            pitAssist = unpacker.NextBool();
            pitReleaseAssist = unpacker.NextBool();
            ERSAssist = unpacker.NextBool();
            DRSAssist = unpacker.NextBool();
            dynamicRacingLine = (Enums.RacingLineAssistMode)unpacker.NextByte();
            isDynamicRacingLine3D = unpacker.NextBool();
        }
    }
}
