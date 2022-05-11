using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
{
    public class UDPListener
    {
        public delegate void OnGetPacket(F1Packet packet);
        OnGetPacket? onGetPacket;

        public UDPListener(IPAddress address, int port)
        {
            Task.Run(async () =>
            {
                using UdpClient client = new UdpClient(new IPEndPoint(address, port));
                while (true)
                {
                    var udpResult = await client.ReceiveAsync();
                    F1Packet packet = F1Packet.CreatePacket(udpResult.Buffer);
                    onGetPacket?.Invoke(packet);
                }
            });
        }

        public void Subscribe(params OnGetPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetPacket += d;
        }

        public void Unsubscribe(params OnGetPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetPacket -= d;
        }
    }
}