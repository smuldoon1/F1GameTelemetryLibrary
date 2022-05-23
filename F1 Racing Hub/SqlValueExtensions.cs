namespace F1_Racing_Hub.Stored_Procedures
{
    public static class SqlValueExtensions
    {

        public static long ToBigint(this ulong value)
        {
            return unchecked((long)value + long.MinValue);
        }

        public static ulong FromBigint(this long value)
        {
            return unchecked((ulong)(value - long.MinValue));
        }
    }
}