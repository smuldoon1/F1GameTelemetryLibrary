namespace F1GameTelemetry_2021
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
