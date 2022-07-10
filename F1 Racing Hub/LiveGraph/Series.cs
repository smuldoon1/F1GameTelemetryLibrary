using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub
{
    public class Series
    {
        public List<Point> Points { get; set; }
        public Color Color { get; set; }
        public int Width { get; set; }

        public Series()
        {
            Points = new List<Point>();
            Color = Color.Red;
            Width = 2;
        }

        public void Draw(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color, Width);
            if (Points.Count > 1)
                graphics.DrawLines(pen, Points.ToArray());
        }
    }
}
