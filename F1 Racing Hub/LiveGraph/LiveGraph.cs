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
        private ComboBox lapNumberComboBox;

        public LiveGraph(PictureBox pictureBox, ComboBox lapNumberComboBox)
        {
            PictureBox = pictureBox;
            //pictureBox.BackColor = Color.Black;
            Series = new List<Series>();
            this.lapNumberComboBox = lapNumberComboBox;
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            Series = new List<Series>();

            var laps = Sql.ExecuteArray<Lap>($"SELECT L.sessionId, L.carIndex, L.number, S.trackLength FROM [F1App].[dbo].[DriverLaps] L JOIN [F1App].[dbo].[Sessions] S ON L.sessionId = S.id WHERE L.sessionId = '{ sessionId }' AND L.number = '{ lapNumberComboBox.SelectedItem }'").ToArray();

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
                            y = frame.Speed.FromSql() + 10f;
                            break;
                        case "Throttle":
                            y = frame.Throttle + 0.1f;
                            break;
                        case "Steer":
                            y = frame.Steer + 1.1f;
                            break;
                        case "Gear":
                            y = frame.Gear.FromSql() + 1.5f;
                            break;
                        case "Brake":
                            y = frame.Brake + 0.1f;
                            break;
                        case "EngineRPM":
                            y = frame.EngineRPM + 100f;
                            break;
                        default:
                            return;
                    }
                    GraphMetric gm = graphMetrics[selectedMetric];
                    Series[i].Points.Add(new Point(
                            (int)(x / (float)laps[i].TrackLength * PictureBox.Bounds.Width),
                            PictureBox.Bounds.Height - (int)(y / gm.Range * PictureBox.Bounds.Height)));
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

        public Dictionary<string, GraphMetric> graphMetrics = new()
        {
            { "Speed" , new GraphMetric { minValue = -10, maxValue = 340 } },
            { "Throttle" , new GraphMetric { minValue = -0.1f, maxValue = 1.1f } },
            { "Steer" , new GraphMetric { minValue = -1.1f, maxValue = 1.1f } },
            { "Gear" , new GraphMetric { minValue = -1.5f, maxValue = 8.5f } },
            { "Brake", new GraphMetric { minValue = -0.1f, maxValue = 1.1f } },
            { "EngineRPM", new GraphMetric { minValue = -100, maxValue = 15100 } }
        };

        public struct GraphMetric
        {
            public float minValue;
            public float maxValue;
            public float Range { get { return maxValue - minValue; } }
        }
    }
}
