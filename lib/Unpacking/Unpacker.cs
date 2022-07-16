using System.Text;

namespace F1GameTelemetry_2021
{
    public class Unpacker
    {
        int pointer = 0;
        byte[]? packedData = null;

        /// <summary>
        /// Creates a new instance of Unpacker and passes in the byte array to unpack.
        /// </summary>
        /// <param name="packedData"></param>
        public Unpacker(byte[] packedData)
        {
            this.packedData = packedData;
        }

        //~Unpacker()
        //{
        //    if (packedData != null)
        //        throw new UnpackingException("Unpacker was freed with unpacked data still remaining. The Finish() method must be called before the Unpacker object goes out of scope.");
        //}

        /// <summary>
        /// Returns all bytes remaining in packedData that have not not been converted yet.
        /// </summary>
        /// <returns></returns>
        public byte[] RetrieveUnconvertedBytes()
        {
            if (packedData == null)
                throw NullError();    
            byte[] data = packedData.Skip(pointer).ToArray();
            packedData = null;
            return data;
        }

        /// <summary>
        /// Should be called whenever the unpacker has finished unpacking. Will throw an error if there are bytes remaining.
        /// </summary>
        public void Finish()
        {
            if (packedData != null && pointer < packedData.Length)
                throw new UnpackingException($"Cannot finish unpacking until { packedData } is empty. There are still { packedData.Length - pointer } bytes left to unpack.");
            packedData = null;
        }

        /// <summary>
        /// Should be called when the unpacker has finished unpacking and the remaining bytes are to be lost.
        /// </summary>
        public void Dump(int numberOfBytesToDump)
        {
            if (packedData != null && packedData.Length - pointer != numberOfBytesToDump)
                throw new UnpackingException($"Cannot dump { packedData }. The specified number of bytes ({ numberOfBytesToDump }) to dump does not match the remaining unpacked bytes ({ packedData.Length - pointer }).");
            packedData = null;
        }

        /// <summary>
        /// Gets the next byte in the byte array and increments the array pointer by 1.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public byte NextByte()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                return packedData[pointer++];
            }
            catch (ArgumentException)
            {
                throw NoDataError(1);
            }
        }

        /// <summary>
        /// Gets the next signed byte in the byte array and increments the array pointer by 1.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public sbyte NextSbyte()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                return unchecked((sbyte)packedData[pointer++]);
            }
            catch (ArgumentException)
            {
                throw NoDataError(1);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        /// <summary>
        /// Gets the next unsigned 16-bit integer in the byte array and increments the array pointer by 2.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public ushort NextUshort()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                ushort value = BitConverter.ToUInt16(packedData, pointer);
                pointer += 2;
                return value;
            }
            catch (ArgumentException)
            {
                throw NoDataError(2);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        /// <summary>
        /// Gets the next signed 16-bit integer in the byte array and increments the array pointer by 2.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public short NextShort()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                short value = BitConverter.ToInt16(packedData, pointer);
                pointer += 2;
                return value;
            }
            catch (ArgumentException)
            {
                throw NoDataError(2);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        /// <summary>
        /// Gets the next unsigned 32-bit integer in the byte array and increments the array pointer by 4.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public uint NextUint()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                uint value = BitConverter.ToUInt32(packedData, pointer);
                pointer += 4;
                return value;
            }
            catch (ArgumentException)
            {
                throw NoDataError(4);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        /// <summary>
        /// Gets the next single in the byte array and increments the array pointer by 4.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public float NextFloat()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                float value = BitConverter.ToSingle(packedData, pointer);
                pointer += 4;
                return value;
            }
            catch (ArgumentException)
            {
                throw NoDataError(4);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        /// <summary>
        /// Gets the next unsigned 64-bit integer in the byte array and increments the array pointer by 8.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public ulong NextUlong()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                ulong value = BitConverter.ToUInt64(packedData, pointer);
                pointer += 8;
                return value;
            }
            catch (ArgumentException)
            {
                throw NoDataError(8);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        /// <summary>
        /// Gets the next double in the byte array and increments the array pointer by 8.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public double NextDouble()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                double value = BitConverter.ToDouble(packedData, pointer);
                pointer += 8;
                return value;
            }
            catch (ArgumentException)
            {
                throw NoDataError(8);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        /// <summary>
        /// Gets the next byte in the byte array and converts it into a boolean value before incrementing the array pointer by 1.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        /// <exception cref="Exception"></exception>
        public bool NextBool()
        {
            if (packedData == null)
                throw NullError();
            try
            {
                byte b = packedData[pointer++];
                if (b == 0)
                    return false;
                if (b == 1)
                    return true;
                throw new UnpackingException($"Value { b } cannot be converted into type bool.");
            }
            catch (ArgumentException)
            {
                throw NoDataError(1);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        /// <summary>
        /// Gets a number of chars in the byte array determined by the length given and combines them to form a string. The array pointer is incremented by 1 for each byte that is converted.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string NextString(int length)
        {
            if (packedData == null)
                throw NullError();
            try
            {
                string s = UTF8Encoding.UTF8.GetString(packedData, pointer, length);
                pointer += length;
                return s.Trim('\0');
            }
            catch (ArgumentException)
            {
                throw NoDataError(length);
            }
            catch (IndexOutOfRangeException)
            {
                throw IndexError();
            }
        }

        UnpackingException NullError()
        {
            return new UnpackingException($"{ packedData } cannot be accessed because it is null. Make sure { packedData } has been passed into the Unpacker and that there is still bytes left to convert.");
        }

        UnpackingException NoDataError(int bytesRequired)
        {
            return new UnpackingException($"Not enough bytes left in { packedData } to unpack. { bytesRequired } bytes are required but there are only { packedData?.Length - pointer } bytes remaining.");
        }

        UnpackingException IndexError()
        {
            return new UnpackingException($"Unpacker pointer ({ pointer }) is out of range. { packedData } has { packedData?.Length } bytes.");
        }
    }
}
