namespace F1GameTelemetry_2021
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
