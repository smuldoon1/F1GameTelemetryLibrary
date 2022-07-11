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

        public LiveGraph(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            pictureBox.BackColor = Color.Black;
            Series = new List<Series>();
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            Series = new List<Series>();

            var laps = Sql.ExecuteArray<Lap>("SELECT sessionId, carIndex, number FROM [F1App].[dbo].[DriverLaps]").ToArray();

            for (int i = 0; i < laps.Length; i++)
            {
                LapFrame[] frames = Sql.ExecuteArray<LapFrame>($"SELECT speed, distance FROM [F1App].[dbo].[LapFrames] WHERE sessionId = { laps[i].SessionId } AND carIndex = { laps[i].CarIndex } AND lapNumber = { laps[i].Number } ORDER BY distance");
                Series.Add(new Series());
                string color = Sql.ExecuteScalar<string>($"SELECT T.colour, T.shortName FROM [F1App].[dbo].[Teams] T JOIN [F1App].[dbo].[Participants] P ON P.teamId = T.id WHERE P.sessionId = { laps[i].SessionId } AND P.carIndex = { laps[i].CarIndex }");
                Series[i].Color = Utilities.GetColor(color ?? "FF00FF", 255);

                foreach (var frame in frames)
                {
                    int x = (int)frame.Distance;
                    int y = frame.Speed.FromSql();
                    Series[i].Points.Add(new Point(
                            (int)(x / 4318f * PictureBox.Bounds.Width),
                            PictureBox.Bounds.Height - (int)(y / 350f * PictureBox.Bounds.Height)));
                }
            }
            foreach (Series s in Series)
            {
                s.Draw(e);
            }
        }

        public class Lap
        {
            public long SessionId { get; set; }

            public byte CarIndex { get; set; }

            public byte Number { get; set; }
        }

        public class LapFrame
        {
            public float Distance { get; set; }

            public short Speed { get; set; }

            public byte Gear { get; set; }

            public float Steer { get; set; }

            public float Throttle { get; set; }
        }
    }
}
