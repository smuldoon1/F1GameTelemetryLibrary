﻿using F1GameTelemetryLibrary.Utils;

namespace F1GameTelemetryLibrary.Damage
{
    /// <summary>
    /// Car damage packet stores damage and wear data for cars in the session.
    /// </summary>
    public partial class CarDamagePacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car damage data.
        /// </summary>
        public CarDamageData[] CarDamageData { get { return carDamageData; } }
    }
}
