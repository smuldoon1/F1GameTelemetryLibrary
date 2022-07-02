namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Damage and wear data for a particular car with numeric data stored as a percentage. For some or all data in this struct only the player, AI cars and network players with their UDP telemetry set to Public will have non-zero values.
    /// </summary>
    public partial class CarDamageData : IPacketStruct
    {
        /// <summary>
        /// Amount of tyre wear.
        /// </summary>
        public TyreData<float> TyreWear { get { return tyreWear; } }

        /// <summary>
        /// Amount of damage to the tyres.
        /// </summary>
        public TyreData<byte> TyreDamage { get { return tyreDamage; } }

        /// <summary>
        /// Amount of damage to the brakes.
        /// </summary>
        public TyreData<byte> BrakeDamage { get { return brakeDamage; } }

        /// <summary>
        /// Amount of damage to the left side of the front wing.
        /// </summary>
        public byte FrontLeftWingDamage { get { return frontLeftWingDamage; } }

        /// <summary>
        /// Amount of damage to the right side of the front wing.
        /// </summary>
        public byte FrontRightWingDamage { get { return frontRightWingDamage; } }

        /// <summary>
        /// Amount of damage to the rear wing.
        /// </summary>
        public byte RearWingDamage { get { return rearWingDamage; } }

        /// <summary>
        /// Amount of damage to the floor.
        /// </summary>
        public byte FloorDamage { get { return floorDamage; } }

        /// <summary>
        /// Amount of damage to the diffuser.
        /// </summary>
        public byte DiffuserDamage { get { return diffuserDamage; } }

        /// <summary>
        /// Amount of damage to the sidepods.
        /// </summary>
        public byte SidepodDamage { get { return sidepodDamage; } }

        /// <summary>
        /// Is there a fault with the drag reduction system?
        /// </summary>
        public bool IsDrsFaulty { get { return isDrsFaulty; } }

        /// <summary>
        /// Is there a fault with the energy recovery system?
        /// </summary>
        public bool IsErsFaulty { get { return isErsFaulty; } }

        /// <summary>
        /// Amount of damage to the gearbox.
        /// </summary>
        public byte GearBoxDamage { get { return gearBoxDamage; } }

        /// <summary>
        /// Amount of damage to the engine.
        /// </summary>
        public byte EngineDamage { get { return engineDamage; } }

        /// <summary>
        /// Amount of wear on the MGU-H.
        /// </summary>
        public byte EngineMGUHWear { get { return engineMGUHWear; } }

        /// <summary>
        /// Amount of wear on the energy store.
        /// </summary>
        public byte EngineESWear { get { return engineESWear; } }

        /// <summary>
        /// Amount of wear on the control electronics.
        /// </summary>
        public byte EngineCEWear { get { return engineCEWear; } }

        /// <summary>
        /// Amount of wear on the internal combustion engine.
        /// </summary>
        public byte EngineICEWear { get { return engineICEWear; } }

        /// <summary>
        /// Amount of wear on the MGU-K.
        /// </summary>
        public byte EngineMGUKWear { get { return engineMGUKWear; } }

        /// <summary>
        /// Amount of wear on the turbo charger.
        /// </summary>
        public byte EngineTCWear { get { return engineTCWear; } }

        /// <summary>
        /// Has the engine blown?
        /// </summary>
        public bool HasEngineBlown { get { return hasEngineBlown; } }

        /// <summary>
        /// Has the engine blown?
        /// </summary>
        public bool HasEngineSeized { get { return hasEngineSeized; } }
    }
}
