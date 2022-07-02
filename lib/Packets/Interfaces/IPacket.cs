namespace F1GameTelemetry_2021
{
    internal interface IPacket
    {
        /// <summary>
        /// Unpacks the data from a byte array into the classes member variables.
        /// </summary>
        /// <param name="packedData"></param>
        void Unpack(byte[] packedData);
    }
}