namespace F1GameTelemetry
{
    /// <summary>
    /// Telemetry data for a particular car.
    /// </summary>
    partial class CarTelemetryData : IPacketStruct
    {
        /// <summary>
        /// Speed of the car in kilometres per hour.
        /// </summary>
        ushort speed;

        /// <summary>
        /// Amount of throttle applied in a range of 0 to 1.
        /// </summary>
        float throttle;

        /// <summary>
        /// Steering value in a range of -1 (full lock left) to 1 (full lock right).
        /// </summary>
        float steer;

        /// <summary>
        /// Amount of brake applied in a range of 0 to 1.
        /// </summary>
        float brake;

        /// <summary>
        /// Percentage of clutch applied.
        /// </summary>
        byte clutch;

        /// <summary>
        /// The selected gear.
        /// </summary>
        sbyte gear;

        /// <summary>
        /// The revolutions per minute of the engines crankshaft.
        /// </summary>
        ushort engineRPM;

        /// <summary>
        /// Is the cars drag reduction system enabled?
        /// </summary>
        bool drs;

        /// <summary>
        /// The percentage of the rev lights indicator.
        /// </summary>
        byte revLightsPercentage;

        /// <summary>
        /// Bit value representing how many LEDs on the rev lights indicator are lit.
        /// </summary>
        ushort revLightsBits;

        /// <summary>
        /// Temperature of the brakes in degrees Celcius.
        /// </summary>
        TyreData<ushort> brakeTemperatures;

        /// <summary>
        /// Temperature of each tyres surface in degrees Celcius.
        /// </summary>
        TyreData<byte> tyreSurfaceTemperatures;

        /// <summary>
        /// Temperature of each tyres carcass in degrees Celcius.
        /// </summary>
        TyreData<byte> tyreInnerTemperature;

        /// <summary>
        /// Engine temperature in degrees Celcius.
        /// </summary>
        ushort engineTemperature;

        /// <summary>
        /// Pressure of each tyre in pounds per square inch.
        /// </summary>
        TyreData<float> tyrePressures;

        /// <summary>
        /// Type of surface each wheel is currently on top of.
        /// </summary>
        TyreData<SurfaceType> surfaceTypes;

        public void Unpack(Unpacker unpacker)
        {
            speed = unpacker.NextUshort();
            throttle = unpacker.NextFloat();
            steer = unpacker.NextFloat();
            brake = unpacker.NextFloat();
            clutch = unpacker.NextByte();
            gear = unpacker.NextSbyte();
            engineRPM = unpacker.NextUshort();
            drs = unpacker.NextBool();
            revLightsPercentage = unpacker.NextByte();
            revLightsBits = unpacker.NextUshort();
            brakeTemperatures = new TyreData<ushort>()
            {
                rearLeft = unpacker.NextUshort(),
                rearRight = unpacker.NextUshort(),
                frontLeft = unpacker.NextUshort(),
                frontRight = unpacker.NextUshort()
            };
            tyreSurfaceTemperatures = new TyreData<byte>()
            {
                rearLeft = unpacker.NextByte(),
                rearRight = unpacker.NextByte(),
                frontLeft = unpacker.NextByte(),
                frontRight = unpacker.NextByte()
            };
            tyreInnerTemperature = new TyreData<byte>()
            {
                rearLeft = unpacker.NextByte(),
                rearRight = unpacker.NextByte(),
                frontLeft = unpacker.NextByte(),
                frontRight = unpacker.NextByte()
            };
            engineTemperature = unpacker.NextUshort();
            tyrePressures = new TyreData<float>()
            {
                rearLeft = unpacker.NextFloat(),
                rearRight = unpacker.NextFloat(),
                frontLeft = unpacker.NextFloat(),
                frontRight = unpacker.NextFloat()
            };
            surfaceTypes = new TyreData<SurfaceType>()
            {
                rearLeft = (SurfaceType)unpacker.NextByte(),
                rearRight = (SurfaceType)unpacker.NextByte(),
                frontLeft = (SurfaceType)unpacker.NextByte(),
                frontRight = (SurfaceType)unpacker.NextByte()
            };
        }
    }
}
