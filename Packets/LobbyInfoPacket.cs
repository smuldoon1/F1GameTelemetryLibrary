using F1GameTelemetryLibrary.Packets;
using F1GameTelemetryLibrary.Packets.Enums;
using F1GameTelemetryLibrary.Packets.Structs;

namespace F1GameTelemetryLibrary
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

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            numberOfPlayers = unpacker.NextByte();
            for (int i = 0; i < lobbyPlayers.Length; i++)
            {
                lobbyPlayers[i].Unpack(unpacker);
            }
        }
    }
}
