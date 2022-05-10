namespace F1GameTelemetryLibrary.Lobbies
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
        public LobbyInfoData[] LobbyPlayers = new LobbyInfoData[F1Globals.MAX_CARS];
    }
}
