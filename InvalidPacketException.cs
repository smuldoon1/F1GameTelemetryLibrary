using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
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
