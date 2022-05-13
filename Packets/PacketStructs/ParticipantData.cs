namespace F1GameTelemetry
{
    /// <summary>
    /// Participant data for a particular car.
    /// </summary>
    partial class ParticipantData : IPacketStruct
    {
        /// <summary>
        /// Is the car being controlled by the AI?
        /// </summary>
        bool isAiControlled;

        /// <summary>
        /// Id of the cars driver.
        /// </summary>
        byte driverId;

        /// <summary>
        /// Unique identifier for network players.
        /// </summary>
        byte networkId;

        /// <summary>
        /// Id of the cars team.
        /// </summary>
        byte teamId;

        /// <summary>
        /// Is the driver driving for the custom team in the MyTeam mode?
        /// </summary>
        bool isMyTeam;

        /// <summary>
        /// Race number of the car.
        /// </summary>
        byte raceNumber;

        /// <summary>
        /// Id of the paticipants nationality.
        /// </summary>
        byte nationalityId;

        /// <summary>
        /// Name of the participant.
        /// </summary>
        string name = "";

        /// <summary>
        /// Is the participants UDP telemetry setting unrestricted?
        /// </summary>
        bool isTelemetryPublic;

        public void Unpack(Unpacker unpacker)
        {
            isAiControlled = unpacker.NextBool();
            driverId = unpacker.NextByte();
            networkId = unpacker.NextByte();
            teamId = unpacker.NextByte();
            isMyTeam = unpacker.NextBool();
            raceNumber = unpacker.NextByte();
            nationalityId = unpacker.NextByte();
            name = unpacker.NextString(48);
            isTelemetryPublic = unpacker.NextBool();
        }
    }
}
