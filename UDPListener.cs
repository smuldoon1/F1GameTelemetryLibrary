using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
{
    public class UDPListener
    {
        public delegate void OnGetMotionPacket(Motion.MotionPacket packet);
        public delegate void OnGetSessionPacket(Sessions.SessionPacket packet);
        public delegate void OnGetLapDataPacket(Laps.LapDataPacket packet);
        public delegate void OnGetEventPacket(Events.EventPacket packet);
        public delegate void OnGetParticipantsPacket(Participants.ParticipantsPacket packet);
        public delegate void OnGetCarSetupsPacket(Setups.CarSetupsPacket packet);
        public delegate void OnGetCarTelemetryPacket(Telemetry.CarTelemetryPacket packet);
        public delegate void OnGetCarStatusPacket(Statuses.CarStatusPacket packet);
        public delegate void OnGetFinalClassificationPacket(Classifications.FinalClassificationPacket packet);
        public delegate void OnGetLobbyInfoPacket(Lobbies.LobbyInfoPacket packet);
        public delegate void OnGetCarDamagePacket(Damage.CarDamagePacket packet);
        public delegate void OnGetSessionHistoryPacket(SessionHistory.SessionHistoryPacket packet);

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

        public UDPListener(IPAddress address, int port)
        {
            Task.Run(async () =>
            {
                using UdpClient client = new UdpClient(new IPEndPoint(address, port));
                while (true)
                {
                    var udpResult = await client.ReceiveAsync();
                    F1Packet packet = F1Packet.CreatePacket(udpResult.Buffer);
                    switch (packet.PacketId)
                    {
                        case PacketId.MOTION:
                            onGetMotionPacket?.Invoke((Motion.MotionPacket)packet);
                            break;
                        case PacketId.SESSION:
                            onGetSessionPacket?.Invoke((Sessions.SessionPacket)packet);
                            break;
                        case PacketId.LAP_DATA:
                            onGetLapDataPacket?.Invoke((Laps.LapDataPacket)packet);
                            break;
                        case PacketId.EVENT:
                            onGetEventPacket?.Invoke((Events.EventPacket)packet);
                            break;
                        case PacketId.PARTICIPANTS:
                            onGetParticipantsPacket?.Invoke((Participants.ParticipantsPacket)packet);
                            break;
                        case PacketId.CAR_SETUPS:
                            onGetCarSetupsPacket?.Invoke((Setups.CarSetupsPacket)packet);
                            break;
                        case PacketId.CAR_TELEMETRY:
                            onGetCarTelemetryPacket?.Invoke((Telemetry.CarTelemetryPacket)packet);
                            break;
                        case PacketId.CAR_STATUS:
                            onGetCarStatusPacket?.Invoke((Statuses.CarStatusPacket)packet);
                            break;
                        case PacketId.FINAL_CLASSIFICATION:
                            onGetFinalClassificationPacket?.Invoke((Classifications.FinalClassificationPacket)packet);
                            break;
                        case PacketId.LOBBY_INFO:
                            onGetLobbyInfoPacket?.Invoke((Lobbies.LobbyInfoPacket)packet);
                            break;
                        case PacketId.CAR_DAMAGE:
                            onGetCarDamagePacket?.Invoke((Damage.CarDamagePacket)packet);
                            break;
                        case PacketId.SESSION_HISTORY:
                            onGetSessionHistoryPacket?.Invoke((SessionHistory.SessionHistoryPacket)packet);
                            break;
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