namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Lobby info about a particular player.
    /// </summary>
    public partial class LobbyInfoData : IPacketStruct
    {
        /// <summary>
        /// Is the car being controlled by the AI?
        /// </summary>
        public bool IsAiControlled { get { return isAiControlled; } }

        /// <summary>
        /// Id of the cars team.
        /// </summary>
        public byte TeamId { get { return teamId; } }

        /// <summary>
        /// Id of the paticipants nationality.
        /// </summary>
        public byte NationalityId { get { return nationalityId; } }

        /// <summary>
        /// Name of the participant.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Race number of the car.
        /// </summary>
        public byte CarNumber { get { return carNumber; } }

        /// <summary>
        /// Ready status of the player.
        /// </summary>
        public ReadyStatus ReadyStatus { get { return readyStatus; } }
    }
}
