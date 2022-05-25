using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using F1GameTelemetry;
using F1_Racing_Hub.Stored_Procedures;

namespace F1_Racing_Hub
{
    public partial class RacingHubListener
    {
        private Dictionary<uint,LapDataPacket> lapDataPackets = new Dictionary<uint, LapDataPacket>();
        private LapHistoryData[,] lapHistories = new LapHistoryData[22, 100];

        private LapFrame[] previousLapFrames = new LapFrame[22];

        public void AddLapsMethods()
        {
            for (int i = 0; i < lapHistories.GetLength(0); i++)
            {
                for (int j = 0; j < lapHistories.GetLength(1); j++)
                {
                    lapHistories[i, j] = new LapHistoryData();
                }
            }

            listener.Subscribe(HandleLapData);
            listener.Subscribe(HandleTelemetryData);
            listener.Subscribe(HandleSessionHistoryData);
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
                    if (CanSaveLapFrame(frame))
                    {
                        LapFrameProc.CreateLapFrame(frame);
                    }
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
                if (lapHistories[i, lap].LapTime > 0 && !LapHistoryProc.CheckLapHistoryDataExists(lapHistories[i, lap]))
                    LapHistoryProc.CreateLapHistoryData(lapHistories[i, lap]);
            }
        }

        private bool CanSaveLapFrame(LapFrame frame)
        {
            // 10 metres is an temporary arbitrary distance threshold
            LapFrame prevFrame = previousLapFrames[frame.CarIndex];
            if (prevFrame == null ||
                frame.Distance > prevFrame.Distance + 10f ||
                frame.LapNumber > prevFrame.LapNumber)
            {
                previousLapFrames[frame.CarIndex] = frame;
                return true;
            }
            return false;
        }
    }
}