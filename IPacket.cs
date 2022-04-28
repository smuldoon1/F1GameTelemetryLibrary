namespace F1GameTelemetryLibrary.Packets
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