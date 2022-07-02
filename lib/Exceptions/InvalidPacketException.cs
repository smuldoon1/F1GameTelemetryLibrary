namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Exception that is thrown whenever an invalid packet index is retrieved from the packet header.
    /// </summary>
    public class InvalidPacketException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the InvalidPacketException class.
        /// </summary>
        public InvalidPacketException()
        {
            
        }

        /// <summary>
        /// Initialises a new instance of the InvalidPacketException class with an error message containing the invalid index number.
        /// </summary>
        /// <param name="packedData"></param>
        public InvalidPacketException(byte packetIndex) :
            base($"No packet exists with an index of { packetIndex }.")
        {

        }
    }
}
