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

            string[] lapIds = Sql.ExecuteArray<Lap>("SELECT [id] FROM [F1App].[dbo].[DriverLaps] WHERE [carIndex] = 0").Select(l => l.id.ToString()).ToArray();

            Random rand = new();
            
            for (int i = 0; i < lapIds.Length; i++)
            {
                LapFrame[] frames = Sql.ExecuteArray<LapFrame>($"SELECT Speed, Distance FROM [F1App].[dbo].[LapFrames] WHERE [lapId] = '{ lapIds[i] }'");
                Series.Add(new Series());
                Series[i].Color = Color.FromArgb(255, rand.Next(255), rand.Next(255), rand.Next(255));
                int prevX = 0;
                foreach (var frame in frames)
                {
                    int x = (int)frame.Distance;
                    int y = frame.Speed.FromSql();
                    Series[i].Points.Add(new Point(
                            (int)(x / 4318f * PictureBox.Bounds.Width),
                            PictureBox.Bounds.Height - (int)(y / 350f * PictureBox.Bounds.Height)));
                    prevX = x;
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
            public Guid id { get; set; }
        }

        public class LapFrame
        {
            public double Distance { get; set; }

            public short Speed { get; set; }
        }
    }
}
