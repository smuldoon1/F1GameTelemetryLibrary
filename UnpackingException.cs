using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// The exception that is thrown whenever an error occurs with the unpacker.
    /// </summary>
    public class UnpackingException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the UnpackingException class.
        /// </summary>
        public UnpackingException()
        {
            
        }

        /// <summary>
        /// Initialises a new instance of the UnpackingException class with an error message.
        /// </summary>
        /// <param name="packedData"></param>
        public UnpackingException(string message) : base(message)
        {

        }
    }
}
