﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
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

        /// <summary>
        /// Returns all bytes remaining in packedData that have not not been converted yet.
        /// </summary>
        /// <returns></returns>
        public byte[] RetrieveUnconvertedBytes()
        {
            if (packedData == null)
                throw new UnpackingException();
            byte[] stolenData = packedData.Skip(pointer).Take(packedData.Length - pointer - 1).ToArray();
            packedData = null;
            return stolenData;
        }

        /// <summary>
        /// Gets the next byte in the byte array and increments the array pointer by 1.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public byte NextByte()
        {
            if (packedData == null)
                throw new UnpackingException();
            return packedData[pointer++];
        }

        /// <summary>
        /// Gets the next signed byte in the byte array and increments the array pointer by 1.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public sbyte NextSbyte()
        {
            if (packedData == null)
                throw new UnpackingException();
            return unchecked((sbyte)packedData[pointer++]);
        }

        /// <summary>
        /// Gets the next unsigned 16-bit integer in the byte array and increments the array pointer by 2.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public ushort NextUshort()
        {
            if (packedData == null)
                throw new UnpackingException();
            return BitConverter.ToUInt16(packedData, pointer += 2);
        }

        /// <summary>
        /// Gets the next signed 16-bit integer in the byte array and increments the array pointer by 2.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public short NextShort()
        {
            if (packedData == null)
                throw new UnpackingException();
            return BitConverter.ToInt16(packedData, pointer += 2);
        }

        /// <summary>
        /// Gets the next unsigned 32-bit integer in the byte array and increments the array pointer by 4.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public uint NextUint()
        {
            if (packedData == null)
                throw new UnpackingException();
            return BitConverter.ToUInt32(packedData, pointer += 4);
        }

        /// <summary>
        /// Gets the next single in the byte array and increments the array pointer by 4.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public float NextFloat()
        {
            if (packedData == null)
                throw new UnpackingException();
            return BitConverter.ToSingle(packedData, pointer += 4);
        }

        /// <summary>
        /// Gets the next unsigned 64-bit integer in the byte array and increments the array pointer by 8.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public ulong NextUlong()
        {
            if (packedData == null)
                throw new UnpackingException();
            return BitConverter.ToUInt64(packedData, pointer += 8);
        }

        /// <summary>
        /// Gets the next double in the byte array and increments the array pointer by 8.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnpackingException"></exception>
        public double NextDouble()
        {
            if (packedData == null)
                throw new UnpackingException();
            return BitConverter.ToDouble(packedData, pointer += 8);
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
                throw new UnpackingException();
            byte b = packedData[pointer++];
            if (b == 0) return false;
            if (b == 1) return true;
            throw new ArithmeticException($"{ b } cannot be converted into type bool.");
        }

        /// <summary>
        /// Gets a number of chars in the byte array determined by the length given and combines them to form a string. The array pointer is incremented by 1 for each byte that is converted.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string NextString(int length)
        {
            if (packedData == null)
                throw new UnpackingException();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = BitConverter.ToChar(packedData, pointer++);
            }
            return new string(chars);
        }
    }
}
