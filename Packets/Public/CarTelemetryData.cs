namespace F1GameTelemetry
{
    /// <summary>
    /// Telemetry data for a particular car.
    /// </summary>
    public partial class CarTelemetryData : IPacketStruct
    {
        /// <summary>
        /// Speed of the car in kilometres per hour.
        /// </summary>
        public ushort Speed { get { return speed; } }

        /// <summary>
        /// Amount of throttle applied in a range of 0 to 1.
        /// </summary>
        public float Throttle { get { return throttle; } }

        /// <summary>
        /// Steering value in a range of -1 (full lock left) to 1 (full lock right).
        /// </summary>
        public float Steer { get { return steer; } }

        /// <summary>
        /// Amount of brake applied in a range of 0 to 1.
        /// </summary>
        public float Brake { get { return brake; } }

        /// <summary>
        /// Percentage of clutch applied.
        /// </summary>
        public byte Clutch { get { return clutch; } }

        /// <summary>
        /// The selected gear.
        /// </summary>
        public sbyte Gear { get { return gear; } }

        /// <summary>
        /// The revolutions per minute of the engines crankshaft.
        /// </summary>
        public ushort EngineRPM { get { return engineRPM; } }

        /// <summary>
        /// Is the cars drag reduction system enabled?
        /// </summary>
        public bool Drs { get { return drs; } }

        /// <summary>
        /// The percentage of the rev lights indicator.
        /// </summary>
        public byte RevLightsPercentage { get { return revLightsPercentage; } }

        /// <summary>
        /// Bit value representing how many LEDs on the rev lights indicator are lit.
        /// </summary>
        public ushort RevLightsBits { get { return revLightsBits; } }

        /// <summary>
        /// Temperature of the brakes in degrees Celcius.
        /// </summary>
        public TyreData<ushort> BrakeTemperatures { get { return brakeTemperatures; } }

        /// <summary>
        /// Temperature of each tyres surface in degrees Celcius.
        /// </summary>
        public TyreData<byte> TyreSurfaceTemperatures { get { return tyreSurfaceTemperatures; } }

        /// <summary>
        /// Temperature of each tyres carcass in degrees Celcius.
        /// </summary>
        public TyreData<byte> TyreInnerTemperature { get { return tyreInnerTemperature; } }

        /// <summary>
        /// Engine temperature in degrees Celcius.
        /// </summary>
        public ushort EngineTemperature { get { return engineTemperature; } }

        /// <summary>
        /// Pressure of each tyre in pounds per square inch.
        /// </summary>
        public TyreData<float> TyrePressures { get { return tyrePressures; } }

        /// <summary>
        /// Type of surface each wheel is currently on top of.
        /// </summary>
        public TyreData<SurfaceType> SurfaceTypes { get { return surfaceTypes; } }
    }
}
