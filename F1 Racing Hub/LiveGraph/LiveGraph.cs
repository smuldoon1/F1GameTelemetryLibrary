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

            var laps = Sql.ExecuteArray<Lap>("SELECT sessionId, carIndex, number FROM [F1App].[dbo].[DriverLaps]").ToArray();

            Random rand = new();
            
            for (int i = 0; i < laps.Length; i++)
            {
                LapFrame[] frames = Sql.ExecuteArray<LapFrame>($"SELECT speed, distance FROM [F1App].[dbo].[LapFrames] WHERE sessionId = { laps[i].sessionId } AND carIndex = { laps[i].carIndex } AND lapNumber = { laps[i].number }");
                Series.Add(new Series());
                Series[i].Color = Color.FromArgb(255, rand.Next(255), rand.Next(255), rand.Next(255));
                foreach (var frame in frames)
                {
                    int x = (int)frame.distance;
                    int y = frame.speed.FromSql();
                    Series[i].Points.Add(new Point(
                            (int)(x / 7004f * PictureBox.Bounds.Width),
                            PictureBox.Bounds.Height - (int)(y / 350f * PictureBox.Bounds.Height)));
                }
                Console.WriteLine(Series[i].Points.Count);
            }
        }

        public void Draw(object sender, PaintEventArgs e)
        {
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
        }
    }
}
