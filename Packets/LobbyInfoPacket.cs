namespace F1GameTelemetryLibrary.Lobbies
{
    /// <summary>
    /// Lobby info packet stores details of the players currently in a multiplayer lobby.
    /// </summary>
    internal class LobbyInfoPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Number of players in the lobby.
        /// </summary>
        byte numberOfPlayers;

        /// <summary>
        /// Array of lobby info for players in the lobby.
        /// </summary>
        LobbyInfoData[] lobbyPlayers = new LobbyInfoData[F1Globals.MAX_CARS];

        public LobbyInfoPacket(PacketHeader header, byte[] remainingData)
        {
            this.header = header;
            Unpack(remainingData);
        }

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            numberOfPlayers = unpacker.NextByte();
            for (int i = 0; i < lobbyPlayers.Length; i++)
            {
                lobbyPlayers[i] = new LobbyInfoData();
                lobbyPlayers[i].Unpack(unpacker);
            }

            unpacker.Finish();
        }
    }
}
