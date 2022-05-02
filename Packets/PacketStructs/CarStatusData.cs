using F1GameTelemetryLibrary.Enums;

namespace F1GameTelemetryLibrary.Statuses
{
    /// <summary>
    /// Status information about a particular car. For some or all data in this stuct only the player, AI cars and network players with their UDP telemetry set to Public will non-zero values.
    /// </summary>
    internal class CarStatusData : IPacketStruct
    {
        /// <summary>
        /// The traction control setting on this car.
        /// </summary>
        Enums.TractionControlMode tractionControl;

        /// <summary>
        /// Is the anti-lock braking system enabled on this car?
        /// </summary>
        bool isABSEnabled;

        /// <summary>
        /// The current fuel mix the car is using.
        /// </summary>
        Enums.FuelMix fuelMix;

        /// <summary>
        /// The brake front brake bias as a percentage.
        /// </summary>
        byte frontBrakeBias;

        /// <summary>
        /// Is the pit limiter on.
        /// </summary>
        bool isPitLimiterOn;

        /// <summary>
        /// The current amount of fuel in the tank.
        /// </summary>
        float fuelInTank;

        /// <summary>
        /// The maximum amount of fuel the tank can hold.
        /// </summary>
        float fuelCapacity;

        /// <summary>
        /// The current amount of fuel in the tank in terms of laps.
        /// </summary>
        float fuelRemainingInLaps;

        /// <summary>
        /// The maximum engine RPM.
        /// </summary>
        ushort maxRPM;

        /// <summary>
        /// The idle RPM the engine runs at.
        /// </summary>
        ushort idleRPM;

        /// <summary>
        /// The maximum number of forward gears available for the car.
        /// </summary>
        byte maxGears;

        /// <summary>
        /// Is DRS allowed to be enabled?
        /// </summary>
        bool isDRSAllowed;

        /// <summary>
        /// The distance in metres before DRS is available. Zero if DRS is not available.
        /// </summary>
        ushort drsActivationDistance;

        /// <summary>
        /// The actual tyre compound that is being used.
        /// </summary>
        ActualTyreCompound tyreCompound;

        /// <summary>
        /// The tyre compound that appears to be on the car. Can be different from the actual tyre compound.
        /// </summary>
        VisualTyreCompound visualTyreCompound;

        /// <summary>
        /// Number of laps the current set of tyres have been used.
        /// </summary>
        byte tyreAge;

        /// <summary>
        /// Flag being waved for this car.
        /// </summary>
        Flag vehicleFiaFlag;

        /// <summary>
        /// Energy stored in joules.
        /// </summary>
        float energyStore;

        /// <summary>
        /// The current deployment mode of the energy recovery system.
        /// </summary>
        Enums.ErsDeployMode energyDeployMode;

        /// <summary>
        /// Energy harvested this lap by the MGU-K.
        /// </summary>
        float lapMGUKineticHarvest;

        /// <summary>
        /// Energy harvested this lap by the MGU-H.
        /// </summary>
        float lapMGUHeatHarvest;

        /// <summary>
        /// Energy deployed this lap.
        /// </summary>
        float lapEnergyDeployed;

        /// <summary>
        /// Is this car paused in a network game?
        /// </summary>
        bool isNetworkPaused;

        void IPacketStruct.Unpack(Unpacker unpacker)
        {
            tractionControl = (Enums.TractionControlMode)unpacker.NextByte();
            isABSEnabled = unpacker.NextBool();
            fuelMix = (Enums.FuelMix)unpacker.NextByte();
            frontBrakeBias = unpacker.NextByte();
            isPitLimiterOn = unpacker.NextBool();
            fuelInTank = unpacker.NextFloat();
            fuelCapacity = unpacker.NextFloat();
            fuelRemainingInLaps = unpacker.NextFloat();
            maxRPM = unpacker.NextUshort();
            idleRPM = unpacker.NextUshort();
            maxGears = unpacker.NextByte();
            isDRSAllowed = unpacker.NextBool();
            drsActivationDistance = unpacker.NextUshort();
            tyreCompound = (ActualTyreCompound)unpacker.NextByte();
            visualTyreCompound = (VisualTyreCompound)unpacker.NextByte();
            tyreAge = unpacker.NextByte();
            vehicleFiaFlag = (Flag)unpacker.NextSbyte();
            energyStore = unpacker.NextFloat();
            energyDeployMode = (Enums.ErsDeployMode)unpacker.NextByte();
            lapMGUKineticHarvest = unpacker.NextFloat();
            lapMGUHeatHarvest = unpacker.NextFloat();
            lapEnergyDeployed = unpacker.NextFloat();
            isNetworkPaused = unpacker.NextBool();
        }
    }
}
