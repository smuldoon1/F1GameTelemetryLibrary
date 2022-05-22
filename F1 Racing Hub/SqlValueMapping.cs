namespace F1_Racing_Hub.Stored_Procedures
{
    public static class SqlValueMapping
    {
        public static long MapToLong(this ulong value)
        {
            return unchecked((long)value + long.MinValue);
        }

        public static ulong MapToUlong(this long value)
        {
            return unchecked((ulong)(value - long.MinValue));
        }
    }
}