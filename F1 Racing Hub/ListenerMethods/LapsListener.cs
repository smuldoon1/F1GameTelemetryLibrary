using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using F1GameTelemetry_2021;

namespace F1_Racing_Hub
{
    public partial class RacingHubListener
    {
        private Dictionary<uint,LapDataPacket> lapDataPackets = new Dictionary<uint, LapDataPacket>();

        private LapFrame[] previousLapFrames = new LapFrame[22];

        public void AddLapsMethods()
        {
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
                    if (lapPacket.LapData[i].ResultStatus == ResultStatus.INACTIVE ||
                        lapPacket.LapData[i].ResultStatus == ResultStatus.INVALID)
                        continue;

                    var l = lapPacket.LapData[i];
                    var t = telemetryPacket.CarTelemetryData[i];
                    //if (CanSaveLapFrame(new LapFrame(i, l.CurrentLap, l.LapDistance)))
                        Sql.Execute($"INSERT INTO [F1App].[dbo].[LapFrames] " +
                            $"(sessionId, carIndex, lapNumber, distance, speed, throttle, steer, brake, gear) VALUES " +
                            $"( { telemetryPacket.SessionUID.ToSql() }, { i }, { l.CurrentLap }, { l.LapDistance }, { t.Speed.ToSql() }, { t.Throttle }, { t.Steer }, { t.Brake }, { t.Gear.ToSql() })");
                }
                lapDataPackets.Remove(telemetryPacket.FrameIdentifier);
            }
        }

        public void HandleSessionHistoryData(SessionHistoryPacket historyPacket)
        {
            byte i = historyPacket.CarIndex;
            for (byte lap = 0; lap < historyPacket.TotalLaps; lap++)
            {
                var lapData = historyPacket.LapHistoryData[lap];
                Sql.Execute(
                    $"BEGIN " +
                        $"IF NOT EXISTS(SELECT sessionId, carIndex, number " +
                        $"FROM [F1App].[dbo].[DriverLaps] " +
                        $"WHERE sessionId = { historyPacket.SessionUID.ToSql() } " +
                        $"AND carIndex = { i } " +
                        $"AND number = { lap }) " +
                        $"BEGIN " +
                            $"INSERT INTO [F1App].[dbo].[DriverLaps] " +
                            $"(sessionId, carIndex, number, time, sectorOneTime, sectorTwoTime, sectorThreeTime) " +
                            $"VALUES({ historyPacket.SessionUID.ToSql() }, { i }, { lap }, { lapData.LapTime.ToSql() }, { lapData.SectorOneTime.ToSql() }, { lapData.SectorTwoTime.ToSql() }, { lapData.SectorThreeTime.ToSql() }) " +
                        $"END " +
                    $"END");
            }
        }

        private bool CanSaveLapFrame(LapFrame frame)
        {
            // 1 metre is an temporary arbitrary distance threshold
            LapFrame prevFrame = previousLapFrames[frame.CarIndex];
            if (prevFrame == null ||
                frame.Distance > prevFrame.Distance + 1f ||
                frame.LapNumber > prevFrame.LapNumber)
            {
                previousLapFrames[frame.CarIndex] = frame;
                return true;
            }
            return false;
        }

        private class LapFrame
        {
            public byte CarIndex;

            public byte LapNumber;

            public float Distance;

            public LapFrame(byte carIndex, byte lapNumber, float distance)
            {
                CarIndex = carIndex;
                LapNumber = lapNumber;
                Distance = distance;
            }
        }
    }
}