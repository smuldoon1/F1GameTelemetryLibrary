using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using F1GameTelemetry;

namespace F1_Racing_Hub
{
    public class ListenerObject
    {
        public List<LapFrame> lapFrames = new List<LapFrame>();

        private Dictionary<uint,LapDataPacket> lapDataPackets = new Dictionary<uint, LapDataPacket>();

        private Participants[] participants = new Participants[22];

        private LapHistory[,] lapHistories = new LapHistory[22, 100];

        private UdpListener listener;

        public ListenerObject()
        {
            for (int i = 0; i < participants.Length; i++)
                participants[i] = new Participants();

            for (int i = 0; i < lapHistories.GetLength(0); i++)
            {
                for (int j = 0; j < lapHistories.GetLength(1); j++)
                {
                    lapHistories[i, j] = new LapHistory();
                }
            }

            listener = new UdpListener(IPAddress.Any, 20777);
            listener.Subscribe(HandleLapData);
            listener.Subscribe(HandleTelemetryData);
            listener.Subscribe(HandleParticipantsData);
            listener.Subscribe(HandleSessionHistoryData);
        }

        public void HandleParticipantsData(ParticipantsPacket participantsPacket)
        {
            for (byte i = 0; i < participantsPacket.Participants.Length; i++)
            {
                participants[i].SessionId = participantsPacket.SessionUID;
                participants[i].CarIndex = i;
                participants[i].DriverId = participantsPacket.Participants[i].DriverId;
                participants[i].Name = participantsPacket.Participants[i].Name;
                participants[i].TeamId = participantsPacket.Participants[i].TeamId;
                participants[i].Nationality = participantsPacket.Participants[i].NationalityId;
                participants[i].RaceNumber = participantsPacket.Participants[i].RaceNumber;
            }
        }

        public void HandleLapData(LapDataPacket lapPacket)
        {
            lapDataPackets.Add(lapPacket.FrameIdentifier, lapPacket);
        }

        public void HandleTelemetryData(CarTelemetryPacket telemetryPacket)
        {
            if (lapDataPackets.Count > 0 && lapDataPackets.ContainsKey(telemetryPacket.FrameIdentifier))
            {
                LapDataPacket lapPacket = lapDataPackets[telemetryPacket.FrameIdentifier];

                for (byte i = 0; i < telemetryPacket.CarTelemetryData.Length; i++)
                {
                    LapFrame frame = new LapFrame()
                    {
                        LapId = lapHistories[i, lapPacket.LapData[i].CurrentLap].Id,
                        SessionId = telemetryPacket.SessionUID,
                        CarIndex = i,
                        LapNumber = lapPacket.LapData[i].CurrentLap,
                        Distance = lapPacket.LapData[i].LapDistance,
                        Speed = telemetryPacket.CarTelemetryData[i].Speed,
                        Throttle = telemetryPacket.CarTelemetryData[i].Throttle,
                        Steer = telemetryPacket.CarTelemetryData[i].Steer,
                        Brake = telemetryPacket.CarTelemetryData[i].Brake,
                        Gear = telemetryPacket.CarTelemetryData[i].Gear
                    };
                    lapFrames.Add(frame);
                }
                lapDataPackets.Remove(telemetryPacket.FrameIdentifier);
            }
        }

        public void HandleSessionHistoryData(SessionHistoryPacket historyPacket)
        {
            byte i = historyPacket.CarIndex;
            for (byte lap = 0; lap < historyPacket.TotalLaps; lap++)
            {
                lapHistories[i, lap].SessionId = historyPacket.SessionUID;
                lapHistories[i, lap].CarIndex = i;
                lapHistories[i, lap].LapNumber = lap;
                lapHistories[i, lap].LapTime = historyPacket.LapHistoryData[lap].LapTime;
                lapHistories[i, lap].SectorOneTime = historyPacket.LapHistoryData[lap].SectorOneTime;
                lapHistories[i, lap].SectorTwoTime = historyPacket.LapHistoryData[lap].SectorTwoTime;
                lapHistories[i, lap].SectorThreeTime = historyPacket.LapHistoryData[lap].SectorThreeTime;
            }
        }
    }
}