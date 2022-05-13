namespace F1GameTelemetry
{
    /// <summary>
    /// Participant data for a particular car.
    /// </summary>
    public partial class ParticipantData : IPacketStruct
    {
        /// <summary>
        /// Is the car being controlled by the AI?
        /// </summary>
        public bool IsAiControlled { get { return isAiControlled; } }

        /// <summary>
        /// Id of the cars driver.
        /// </summary>
        public byte DriverId { get { return driverId; } }

        /// <summary>
        /// Unique identifier for network players.
        /// </summary>
        public byte NetworkId { get { return networkId; } }

        /// <summary>
        /// Id of the cars team.
        /// </summary>
        public byte TeamId { get { return teamId; } }

        /// <summary>
        /// Is the driver driving for the custom team in the MyTeam mode?
        /// </summary>
        public bool IsMyTeam { get { return isMyTeam; } }

        /// <summary>
        /// Race number of the car.
        /// </summary>
        public byte RaceNumber { get { return raceNumber; } }

        /// <summary>
        /// Id of the paticipants nationality.
        /// </summary>
        public byte NationalityId { get { return nationalityId; } }

        /// <summary>
        /// Name of the participant.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Is the participants UDP telemetry setting unrestricted?
        /// </summary>
        public bool IsTelemetryPublic { get { return isTelemetryPublic; } }
    }
}
