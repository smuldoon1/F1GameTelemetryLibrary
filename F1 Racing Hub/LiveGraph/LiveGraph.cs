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
                LapFrame[] frames = Sql.ExecuteArray<LapFrame>($"SELECT speed, distance FROM [F1App].[dbo].[LapFrames] WHERE sessionId = { laps[i].sessionId } AND carIndex = { laps[i].carIndex } AND lapNumber = { laps[i].number } ORDER BY distance");
                Series.Add(new Series());
                string color = Sql.ExecuteScalar<string>($"SELECT T.colour, T.shortName FROM [F1App].[dbo].[Teams] T JOIN [F1App].[dbo].[Participants] P ON P.teamId = T.id WHERE P.sessionId = { laps[i].sessionId } AND P.carIndex = { laps[i].carIndex }");
                Series[i].Color = Utilities.GetColor(color ?? "FF00FF", 255);

                foreach (var frame in frames)
                {
                    int x = (int)frame.distance;
                    int y = frame.speed.FromSql();
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
            public long sessionId { get; set; }

            public byte carIndex { get; set; }

            public byte number { get; set; }
        }

        public class LapFrame
        {
            public double distance { get; set; }

            public short speed { get; set; }

            public byte gear { get; set; }

            public double steer { get; set; }

            public double throttle { get; set; }
        }
    }
}
