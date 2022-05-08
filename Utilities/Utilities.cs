using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary.Util
{
    public class Utilities
    {
        public static float KphToMph(float kph)
        {
            return kph * 0.621371f;
        }

        public static float PsiToBar(float psi)
        {
            return psi * 0.0689476f;
        }
    }
}
