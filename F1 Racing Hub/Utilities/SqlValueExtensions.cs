namespace F1_Racing_Hub
{
    /// <summary>
    /// Extension methods that allow some data types to be mapped to T-SQL values. If a conversion method does not exist it is likely that the conversion is implicit.
    /// </summary>
    public static class SqlValueExtensions
    {
        /// <summary>
        /// Converts an unsigned 64-bit integer to a T-SQL bigint.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToSql(this ulong value)
        {
            return unchecked((long)value + long.MinValue);
        }

        /// <summary>
        /// Converts a T-SQL bigint to an unsigned 64-bit integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ulong FromSql(this long value)
        {
            return unchecked((ulong)(value - long.MinValue));
        }

        /// <summary>
        /// Converts an unsigned 32-bit integer to a T-SQL int.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToSql(this uint value)
        {
            return unchecked((int)value + int.MinValue);
        }

        /// <summary>
        /// Converts a T-SQL int to an unsigned 32-bit integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint FromSql(this int value)
        {
            return unchecked((uint)(value - int.MinValue));
        }

        /// <summary>
        /// Converts an unsigned 16-bit integer to a T-SQL smallint.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short ToSql(this ushort value)
        {
            return unchecked((short)(value + short.MinValue));
        }

        /// <summary>
        /// Converts a T-SQL smallint to an unsigned 16-bit integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ushort FromSql(this short value)
        {
            return unchecked((ushort)(value - short.MinValue));
        }

        /// <summary>
        /// Converts a signed byte to a T-SQL tinyint.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToSql(this sbyte value)
        {
            return unchecked((byte)(value - sbyte.MinValue));
        }

        /// <summary>
        /// Converts a T-SQL tinyint to a signed byte.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static sbyte FromSql(this byte value)
        {
            return unchecked((sbyte)(value + sbyte.MinValue));
        }

        public static string ToSql(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd HH:mm:ss");
        }
    }
}