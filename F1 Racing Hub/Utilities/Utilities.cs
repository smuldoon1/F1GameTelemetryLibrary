using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub
{
    public static class Utilities
    {
        public static Color GetColor(string color, int alpha)
        {
            int r = int.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int g = int.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int b = int.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(alpha, r, g, b);
        }
    }
}
