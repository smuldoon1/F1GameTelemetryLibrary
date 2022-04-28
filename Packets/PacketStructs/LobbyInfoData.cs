using F1GameTelemetryLibrary.Packets;
using F1GameTelemetryLibrary.Packets.Enums;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Lobby info about a particular player.
    /// </summary>
    internal struct LobbyInfoData : IPacketStruct
    {
        /// <summary>
        /// Is the car being controlled by the AI?
        /// </summary>
        bool isAiControlled;

        /// <summary>
        /// Id of the cars team.
        /// </summary>
        byte teamId;

        /// <summary>
        /// Id of the paticipants nationality.
        /// </summary>
        byte nationalityId;

        /// <summary>
        /// Name of the participant.
        /// </summary>
        string name;

        /// <summary>
        /// Race number of the car.
        /// </summary>
        byte carNumber;

        /// <summary>
        /// Ready status of the player.
        /// </summary>
        ReadyStatus readyStatus;

        public void Unpack(Unpacker unpacker)
        {
            isAiControlled = unpacker.NextBool();
            teamId = unpacker.NextByte();
            nationalityId = unpacker.NextByte();
            name = unpacker.NextString(48);
            carNumber = unpacker.NextByte();
            readyStatus = (ReadyStatus)unpacker.NextByte();
        }
    }
}
