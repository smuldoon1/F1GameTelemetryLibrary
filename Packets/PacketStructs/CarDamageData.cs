using F1GameTelemetryLibrary.Utils;

namespace F1GameTelemetryLibrary.Damage
{
    /// <summary>
    /// Damage and wear data for a particular car with numeric data stored as a percentage. For some or all data in this struct only the player, AI cars and network players with their UDP telemetry set to Public will have non-zero values.
    /// </summary>
    internal class CarDamageData : IPacketStruct
    {
        /// <summary>
        /// Amount of tyre wear.
        /// </summary>
        TyreData<float> tyreWear;

        /// <summary>
        /// Amount of damage to the tyres.
        /// </summary>
        TyreData<byte> tyreDamage;

        /// <summary>
        /// Amount of damage to the brakes.
        /// </summary>
        TyreData<byte> brakeDamage;

        /// <summary>
        /// Amount of damage to the left side of the front wing.
        /// </summary>
        byte frontLeftWingDamage;

        /// <summary>
        /// Amount of damage to the right side of the front wing.
        /// </summary>
        byte frontRightWingDamage;

        /// <summary>
        /// Amount of damage to the rear wing.
        /// </summary>
        byte rearWingDamage;

        /// <summary>
        /// Amount of damage to the floor.
        /// </summary>
        byte floorDamage;

        /// <summary>
        /// Amount of damage to the diffuser.
        /// </summary>
        byte diffuserDamage;

        /// <summary>
        /// Amount of damage to the sidepods.
        /// </summary>
        byte sidepodDamage;

        /// <summary>
        /// Is there a fault with the drag reduction system?
        /// </summary>
        bool isDrsFaulty;

        /// <summary>
        /// Amount of damage to the gearbox.
        /// </summary>
        byte gearBoxDamage;

        /// <summary>
        /// Amount of damage to the engine.
        /// </summary>
        byte engineDamage;

        /// <summary>
        /// Amount of wear on the MGU-H.
        /// </summary>
        byte engineMGUHWear;

        /// <summary>
        /// Amount of wear on the energy store.
        /// </summary>
        byte engineESWear;

        /// <summary>
        /// Amount of wear on the control electronics.
        /// </summary>
        byte engineCEWear;

        /// <summary>
        /// Amount of wear on the internal combustion engine.
        /// </summary>
        byte engineICEWear;

        /// <summary>
        /// Amount of wear on the MGU-K.
        /// </summary>
        byte engineMGUKWear;

        /// <summary>
        /// Amount of wear on the turbo charger.
        /// </summary>
        byte engineTCWear;

        void IPacketStruct.Unpack(Unpacker unpacker)
        {
            tyreWear = new TyreData<float>()
            {
                rearLeft = unpacker.NextFloat(),
                rearRight = unpacker.NextFloat(),
                frontLeft = unpacker.NextFloat(),
                frontRight = unpacker.NextFloat()
            };
            tyreDamage = new TyreData<byte>()
            {
                rearLeft = unpacker.NextByte(),
                rearRight = unpacker.NextByte(),
                frontLeft = unpacker.NextByte(),
                frontRight = unpacker.NextByte()
            };
            brakeDamage = new TyreData<byte>()
            {
                rearLeft = unpacker.NextByte(),
                rearRight = unpacker.NextByte(),
                frontLeft = unpacker.NextByte(),
                frontRight = unpacker.NextByte()
            };
            frontLeftWingDamage = unpacker.NextByte();
            frontRightWingDamage = unpacker.NextByte();
            rearWingDamage = unpacker.NextByte();
            floorDamage = unpacker.NextByte();
            diffuserDamage = unpacker.NextByte();
            sidepodDamage = unpacker.NextByte();
            isDrsFaulty = unpacker.NextBool();
            gearBoxDamage = unpacker.NextByte();
            engineDamage = unpacker.NextByte();
            engineMGUHWear = unpacker.NextByte();
            engineESWear = unpacker.NextByte();
            engineCEWear = unpacker.NextByte();
            engineICEWear = unpacker.NextByte();
            engineMGUKWear = unpacker.NextByte();
            engineTCWear = unpacker.NextByte();
        }
    }
}
