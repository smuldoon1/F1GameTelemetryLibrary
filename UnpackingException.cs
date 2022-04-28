using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// The exception that is thrown whenever Unpacker attempts to access a null byte array.
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
        /// Initialises a new instance of the UnpackingException class with an error message containing the name of the null byte array.
        /// </summary>
        /// <param name="packedData"></param>
        public UnpackingException(string packedData) :
            base($"{ packedData } cannot be accessed because it is null. Make sure { packedData } has been passed into the Unpacker and that there is still bytes left to convert.")
        {

        }
    }
}
