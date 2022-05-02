using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
{
    public class GameConnector
    {
        public void CreateConnection()
        {
            UdpClient udpServer;
            try
            {
                udpServer = new UdpClient(new IPEndPoint(IPAddress.Any, 20777));
            }
            catch (SocketException ex)
            {
                throw ex;
            }

            IPEndPoint? remoteEndPoint = null;  
            while (true)
            {
                byte[] udpData = udpServer.Receive(ref remoteEndPoint);
                F1Packet packet = F1Packet.CreatePacket(udpData);
            }
        }
    }
}