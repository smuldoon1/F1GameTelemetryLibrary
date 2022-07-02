namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Status information about a particular car. For some or all data in this stuct only the player, AI cars and network players with their UDP telemetry set to Public will non-zero values.
    /// </summary>
    public partial class CarStatusData : IPacketStruct
    {
        /// <summary>
        /// The traction control setting on this car.
        /// </summary>
        public TractionControlMode TractionControl { get { return tractionControl; } }

        /// <summary>
        /// Is the anti-lock braking system enabled on this car?
        /// </summary>
        public bool IsABSEnabled { get { return isABSEnabled; } }

        /// <summary>
        /// The current fuel mix the car is using.
        /// </summary>
        public FuelMix FuelMix { get { return fuelMix; } }

        /// <summary>
        /// The brake front brake bias as a percentage.
        /// </summary>
        public byte FrontBrakeBias { get { return frontBrakeBias; } }

        /// <summary>
        /// Is the pit limiter on.
        /// </summary>
        public bool IsPitLimiterOn { get { return isPitLimiterOn; } }

        /// <summary>
        /// The current amount of fuel in the tank.
        /// </summary>
        public float FuelInTank { get { return fuelInTank; } }

        /// <summary>
        /// The maximum amount of fuel the tank can hold.
        /// </summary>
        public float FuelCapacity { get { return fuelCapacity; } }

        /// <summary>
        /// The current amount of fuel in the tank in terms of laps.
        /// </summary>
        public float FuelRemainingInLaps { get { return fuelRemainingInLaps; } }

        /// <summary>
        /// The maximum engine RPM.
        /// </summary>
        public ushort MaxRPM { get { return maxRPM; } }

        /// <summary>
        /// The idle RPM the engine runs at.
        /// </summary>
        public ushort IdleRPM { get { return idleRPM; } }

        /// <summary>
        /// The maximum number of forward gears available for the car.
        /// </summary>
        public byte MaxGears { get { return maxGears; } }

        /// <summary>
        /// Is DRS allowed to be enabled?
        /// </summary>
        public bool IsDRSAllowed { get { return isDRSAllowed; } }

        /// <summary>
        /// The distance in metres before DRS is available. Zero if DRS is not available.
        /// </summary>
        public ushort DrsActivationDistance { get { return drsActivationDistance; } }

        /// <summary>
        /// The actual tyre compound that is being used.
        /// </summary>
        public ActualTyreCompound TyreCompound { get { return tyreCompound; } }

        /// <summary>
        /// The tyre compound that appears to be on the car. Can be different from the actual tyre compound.
        /// </summary>
        public VisualTyreCompound VisualTyreCompound { get { return visualTyreCompound; } }

        /// <summary>
        /// Number of laps the current set of tyres have been used.
        /// </summary>
        public byte TyreAge { get { return tyreAge; } }

        /// <summary>
        /// Flag being waved for this car.
        /// </summary>
        public Flag VehicleFiaFlag { get { return vehicleFiaFlag; } }

        /// <summary>
        /// Energy stored in joules.
        /// </summary>
        public float EnergyStore { get { return energyStore; } }

        /// <summary>
        /// The current deployment mode of the energy recovery system.
        /// </summary>
        public ErsDeployMode EnergyDeployMode { get { return energyDeployMode; } }

        /// <summary>
        /// Energy harvested this lap by the MGU-K.
        /// </summary>
        public float LapMGUKineticHarvest { get { return lapMGUKineticHarvest; } }

        /// <summary>
        /// Energy harvested this lap by the MGU-H.
        /// </summary>
        public float LapMGUHeatHarvest { get { return lapMGUHeatHarvest; } }

        /// <summary>
        /// Energy deployed this lap.
        /// </summary>
        public float LapEnergyDeployed { get { return lapEnergyDeployed; } }

        /// <summary>
        /// Is this car paused in a network game?
        /// </summary>
        public bool IsNetworkPaused { get { return isNetworkPaused; } }
    }
}
