using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub
{
    public class LiveGraph
    {
        public PictureBox PictureBox { get; }
        public List<Series> Series { get; set; }
        public string selectedMetric { get; set; } = "Speed";

        private string sessionId = "";
        private int trackLength;
        private ComboBox lapNumberComboBox;
        private Label trackLengthLabel;
        private Label minYAxisLabel;
        private Label maxYAxisLabel;
        private ListView driverListView;

        public LiveGraph(PictureBox pictureBox, ComboBox lapNumber, Label trackLength, Label minYAxis, Label maxYAxis, ListView driverList)
        {
            PictureBox = pictureBox;
            Series = new List<Series>();
            lapNumberComboBox = lapNumber;
            trackLengthLabel = trackLength;
            minYAxisLabel = minYAxis;
            maxYAxisLabel = maxYAxis;
            driverListView = driverList;
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            Series = new List<Series>();

            var laps = Sql.ExecuteArray<Lap>($"SELECT L.sessionId, L.carIndex, L.number, S.trackLength FROM [F1App].[dbo].[DriverLaps] L JOIN [F1App].[dbo].[Sessions] S ON L.sessionId = S.id WHERE L.sessionId = '{ sessionId }' AND L.number = '{ lapNumberComboBox.SelectedItem }'").ToArray();
            if (laps.Count() > 0)
                trackLengthLabel.Text = laps.First().TrackLength.ToString() + " m";

            for (int i = 0; i < laps.Length; i++)
            {
                LapFrame[] frames = Sql.ExecuteArray<LapFrame>($"SELECT { selectedMetric }, distance FROM [F1App].[dbo].[LapFrames] WHERE sessionId = { laps[i].SessionId } AND carIndex = { laps[i].CarIndex } AND lapNumber = { laps[i].Number } ORDER BY distance");
                Series.Add(new Series());
                string color = Sql.ExecuteScalar<string>($"SELECT T.colour, T.shortName FROM [F1App].[dbo].[Teams] T JOIN [F1App].[dbo].[Participants] P ON P.teamId = T.id WHERE P.sessionId = { laps[i].SessionId } AND P.carIndex = { laps[i].CarIndex }");
                Series[i].Color = Utilities.GetColor(color ?? "FF00FF", 255);

                foreach (var frame in frames)
                {
                    int x = (int)frame.Distance;
                    float y;
                    switch (selectedMetric)
                    {
                        case "Speed":
                            y = frame.Speed.FromSql();
                            break;
                        case "Throttle":
                            y = frame.Throttle;
                            break;
                        case "Steer":
                            y = frame.Steer;
                            break;
                        case "Gear":
                            y = frame.Gear.FromSql();
                            break;
                        case "Brake":
                            y = frame.Brake;
                            break;
                        case "EngineRPM":
                            y = frame.EngineRPM.FromSql();
                            break;
                        default:
                            return;
                    }
                    if (selectedMetric != "Brake" && y == 0)
                        continue;

                    GraphMetric gm = graphMetrics[selectedMetric];
                    minYAxisLabel.Text = gm.minValue.ToString() + gm.unit ?? "";
                    maxYAxisLabel.Text = gm.maxValue.ToString() + gm.unit ?? "";
                    float gap = gm.Range * 0.05f;
                    Series[i].Points.Add(new Point(
                            (int)(x / (float)laps[i].TrackLength * PictureBox.Bounds.Width),
                            PictureBox.Bounds.Height - (int)((y - gm.minValue + gap) / (gm.Range + gap * 2f) * PictureBox.Bounds.Height)));
                }
            }
            foreach (Series s in Series)
            {
                s.Draw(e);
            }
        }

        public void SetSession(string sessionId)
        {
            this.sessionId = sessionId;
            var laps = Sql.ExecuteArray<Lap>($"SELECT DISTINCT DL.number FROM [F1App].[dbo].[DriverLaps] DL JOIN [F1App].[dbo].[LapFrames] LF ON DL.number = LF.lapNumber WHERE DL.sessionId = '{ sessionId }'").ToArray();
            lapNumberComboBox.Items.Clear();
            lapNumberComboBox.Items.AddRange(laps.Select(l => (object)l.Number).ToArray());
            if (lapNumberComboBox.Items.Count > 0)
                lapNumberComboBox.SelectedIndex = 0;

            driverListView.Items.Clear();
            var driverInfo = Sql.ExecuteArray<DriverInfo>($"SELECT name, teamId, raceNumber FROM [F1App].[dbo].[Participants] WHERE sessionId = { sessionId }").ToList();
            driverInfo.ForEach(d => driverListView.Items.Add(new ListViewItem(new string[] { d.Name, "#" + d.RaceNumber, d.TeamId.ToString() })));  
        }

        public class Lap
        {
            public long SessionId { get; set; }

            public byte CarIndex { get; set; }

            public byte Number { get; set; }

            public int TrackLength { get; set; }
        }

        public class LapFrame
        {
            public float Distance { get; set; }

            public short Speed { get; set; }

            public byte Gear { get; set; }

            public float Steer { get; set; }

            public float Throttle { get; set; }

            public float Brake { get; set; }

            public short EngineRPM { get; set; }
        }

        private class DriverInfo
        {
            public string Name { get; set; }

            public int TeamId { get; set; }

            public int RaceNumber { get; set; }
        }

        public Dictionary<string, GraphMetric> graphMetrics = new()
        {
            { "Speed" , new GraphMetric { minValue = 0, maxValue = 350, unit = "kph" } },
            { "Throttle" , new GraphMetric { minValue = 0, maxValue = 1 } },
            { "Steer" , new GraphMetric { minValue = -1, maxValue = 1 } },
            { "Gear" , new GraphMetric { minValue = -1, maxValue = 8 } },
            { "Brake" , new GraphMetric { minValue = 0, maxValue = 1 } },
            { "EngineRPM" , new GraphMetric { minValue = 0, maxValue = 15000, unit = "rpm"} }
        };

        public struct GraphMetric
        {
            public int minValue;
            public int maxValue;
            public string? unit;
            public int Range { get { return maxValue - minValue; } }
        }
    }
}
