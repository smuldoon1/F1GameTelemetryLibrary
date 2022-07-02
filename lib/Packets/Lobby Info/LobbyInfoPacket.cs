namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Lobby info packet stores details of the players currently in a multiplayer lobby.
    /// </summary>
    public partial class LobbyInfoPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Number of players in the lobby.
        /// </summary>
        public byte NumberOfPlayers;

        /// <summary>
        /// Array of lobby info for players in the lobby.
        /// </summary>
        public LobbyInfoData[] LobbyPlayers { get { return lobbyPlayers; } }
    }
}
