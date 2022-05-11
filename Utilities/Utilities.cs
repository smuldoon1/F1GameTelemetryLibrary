using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary.Utils
{
    public class Utilities
    {
        public static int KphToMph(int kph)
        {
            return (int)Math.Round(kph * 0.621371f);
        }

        public static float PsiToBar(float psi)
        {
            return psi * 0.0689476f;
        }
    }
}
