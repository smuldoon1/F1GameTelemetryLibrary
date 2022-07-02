using System.Net;
using System.Net.Sockets;

namespace F1GameTelemetry_2021
{
    public class UdpListener
    {
        public delegate void OnGetMotionPacket(MotionPacket packet);
        public delegate void OnGetSessionPacket(SessionPacket packet);
        public delegate void OnGetLapDataPacket(LapDataPacket packet);
        public delegate void OnGetEventPacket(EventPacket packet);
        public delegate void OnGetParticipantsPacket(ParticipantsPacket packet);
        public delegate void OnGetCarSetupsPacket(CarSetupsPacket packet);
        public delegate void OnGetCarTelemetryPacket(CarTelemetryPacket packet);
        public delegate void OnGetCarStatusPacket(CarStatusPacket packet);
        public delegate void OnGetFinalClassificationPacket(FinalClassificationPacket packet);
        public delegate void OnGetLobbyInfoPacket(LobbyInfoPacket packet);
        public delegate void OnGetCarDamagePacket(CarDamagePacket packet);
        public delegate void OnGetSessionHistoryPacket(SessionHistoryPacket packet);

        OnGetMotionPacket? onGetMotionPacket;
        OnGetSessionPacket? onGetSessionPacket;
        OnGetLapDataPacket? onGetLapDataPacket;
        OnGetEventPacket? onGetEventPacket;
        OnGetParticipantsPacket? onGetParticipantsPacket;
        OnGetCarSetupsPacket? onGetCarSetupsPacket;
        OnGetCarTelemetryPacket? onGetCarTelemetryPacket;
        OnGetCarStatusPacket? onGetCarStatusPacket;
        OnGetFinalClassificationPacket? onGetFinalClassificationPacket;
        OnGetLobbyInfoPacket? onGetLobbyInfoPacket;
        OnGetCarDamagePacket? onGetCarDamagePacket;
        OnGetSessionHistoryPacket? onGetSessionHistoryPacket;

        public UdpListener(IPAddress address, int port)
        {
            Task.Run(async () =>
            {
                using UdpClient client = new UdpClient(new IPEndPoint(address, port));
                while (true)
                {
                    try
                    {
                        var udpResult = await client.ReceiveAsync();
                        F1Packet packet = F1Packet.CreatePacket(udpResult.Buffer);
                        switch (packet.PacketId)
                        {
                            case PacketId.MOTION:
                                onGetMotionPacket?.Invoke((MotionPacket)packet);
                                break;
                            case PacketId.SESSION:
                                onGetSessionPacket?.Invoke((SessionPacket)packet);
                                break;
                            case PacketId.LAP_DATA:
                                onGetLapDataPacket?.Invoke((LapDataPacket)packet);
                                break;
                            case PacketId.EVENT:
                                onGetEventPacket?.Invoke((EventPacket)packet);
                                break;
                            case PacketId.PARTICIPANTS:
                                onGetParticipantsPacket?.Invoke((ParticipantsPacket)packet);
                                break;
                            case PacketId.CAR_SETUPS:
                                onGetCarSetupsPacket?.Invoke((CarSetupsPacket)packet);
                                break;
                            case PacketId.CAR_TELEMETRY:
                                onGetCarTelemetryPacket?.Invoke((CarTelemetryPacket)packet);
                                break;
                            case PacketId.CAR_STATUS:
                                onGetCarStatusPacket?.Invoke((CarStatusPacket)packet);
                                break;
                            case PacketId.FINAL_CLASSIFICATION:
                                onGetFinalClassificationPacket?.Invoke((FinalClassificationPacket)packet);
                                break;
                            case PacketId.LOBBY_INFO:
                                onGetLobbyInfoPacket?.Invoke((LobbyInfoPacket)packet);
                                break;
                            case PacketId.CAR_DAMAGE:
                                onGetCarDamagePacket?.Invoke((CarDamagePacket)packet);
                                break;
                            case PacketId.SESSION_HISTORY:
                                onGetSessionHistoryPacket?.Invoke((SessionHistoryPacket)packet);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            });
        }

        public void Subscribe(params OnGetMotionPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetMotionPacket += d;
        }

        public void Subscribe(params OnGetSessionPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetSessionPacket += d;
        }

        public void Subscribe(params OnGetLapDataPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetLapDataPacket += d;
        }

        public void Subscribe(params OnGetEventPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetEventPacket += d;
        }

        public void Subscribe(params OnGetParticipantsPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetParticipantsPacket += d;
        }

        public void Subscribe(params OnGetCarSetupsPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetCarSetupsPacket += d;
        }

        public void Subscribe(params OnGetCarTelemetryPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetCarTelemetryPacket += d;
        }

        public void Subscribe(params OnGetCarStatusPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetCarStatusPacket += d;
        }

        public void Subscribe(params OnGetFinalClassificationPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetFinalClassificationPacket += d;
        }

        public void Subscribe(params OnGetLobbyInfoPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetLobbyInfoPacket += d;
        }

        public void Subscribe(params OnGetCarDamagePacket[] delegates)
        {
            foreach (var d in delegates)
                onGetCarDamagePacket += d;
        }

        public void Subscribe(params OnGetSessionHistoryPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetSessionHistoryPacket += d;
        }

        public void Unsubscribe(params OnGetMotionPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetMotionPacket -= d;
        }

        public void Unsubscribe(params OnGetSessionPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetSessionPacket -= d;
        }

        public void Unsubscribe(params OnGetLapDataPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetLapDataPacket -= d;
        }

        public void Unsubscribe(params OnGetEventPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetEventPacket -= d;
        }

        public void Unsubscribe(params OnGetParticipantsPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetParticipantsPacket -= d;
        }

        public void Unsubscribe(params OnGetCarSetupsPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetCarSetupsPacket -= d;
        }

        public void Unsubscribe(params OnGetCarTelemetryPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetCarTelemetryPacket -= d;
        }

        public void Unsubscribe(params OnGetCarStatusPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetCarStatusPacket -= d;
        }

        public void Unsubscribe(params OnGetFinalClassificationPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetFinalClassificationPacket -= d;
        }

        public void Unsubscribe(params OnGetLobbyInfoPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetLobbyInfoPacket -= d;
        }

        public void Unsubscribe(params OnGetCarDamagePacket[] delegates)
        {
            foreach (var d in delegates)
                onGetCarDamagePacket -= d;
        }

        public void Unsubscribe(params OnGetSessionHistoryPacket[] delegates)
        {
            foreach (var d in delegates)
                onGetSessionHistoryPacket -= d;
        }
    }
}