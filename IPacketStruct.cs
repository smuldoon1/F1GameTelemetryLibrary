﻿namespace F1GameTelemetryLibrary
{
    internal interface IPacketStruct
    {
        /// <summary>
        /// Unpacks data for a packet struct.
        /// </summary>
        /// <param name="unpacker"></param>
        void Unpack(Unpacker unpacker);
    }
}