namespace F1GameTelemetry
{
    /// <summary>
    /// Car setup values for a particular car.
    /// </summary>
    partial class CarSetupData  : IPacketStruct
    {
        /// <summary>
        /// Front wing aero angle.
        /// </summary>
        byte frontWing;

        /// <summary>
        /// Rear wing aero angle.
        /// </summary>
        byte rearWing;

        /// <summary>
        /// Differential adjustment on throttle as a percentage.
        /// </summary>
        byte onThrottle;

        /// <summary>
        /// Differential adjustment off throttle as a percentage.
        /// </summary>
        byte offThrottle;

        /// <summary>
        /// Front camber angle of suspension geometry.
        /// </summary>
        float frontCamber;

        /// <summary>
        /// Rear camber angle of suspension geometry.
        /// </summary>
        float rearCamber;

        /// <summary>
        /// Front toe angle of suspension geometry.
        /// </summary>
        float frontToe;

        /// <summary>
        /// Rear toe angle of suspension geometry.
        /// </summary>
        float rearToe;

        /// <summary>
        /// Front suspension amount.
        /// </summary>
        byte frontSuspension;

        /// <summary>
        /// Rear suspension amount.
        /// </summary>
        byte rearSuspension;

        /// <summary>
        /// Front anti-roll bar amount.
        /// </summary>
        byte frontAntiRollBar;

        /// <summary>
        /// Rear anti-roll bar amount.
        /// </summary>
        byte rearAntiRollBar;

        /// <summary>
        /// Front ride height.
        /// </summary>
        byte frontSuspensionHeight;

        /// <summary>
        /// Rear ride height.
        /// </summary>
        byte rearSuspensionHeight;

        /// <summary>
        /// Brake pressure as a percentage.
        /// </summary>
        byte brakePressure;

        /// <summary>
        /// Brake bias as a percentage.
        /// </summary>
        byte brakeBias;

        /// <summary>
        /// Tyre pressures in pounds per square inch.
        /// </summary>
        TyreData<float> tyrePressures;

        /// <summary>
        /// The amount of ballast.
        /// </summary>
        byte ballast;

        /// <summary>
        /// The amount of fuel in litres.
        /// </summary>
        float fuelLoad;

        public void Unpack(Unpacker unpacker)
        {
            frontWing = unpacker.NextByte();
            rearWing = unpacker.NextByte();
            onThrottle = unpacker.NextByte();
            offThrottle = unpacker.NextByte();
            frontCamber = unpacker.NextFloat();
            rearCamber = unpacker.NextFloat();
            frontToe = unpacker.NextFloat();
            rearToe = unpacker.NextFloat();
            frontSuspension = unpacker.NextByte();
            rearSuspension = unpacker.NextByte();
            frontAntiRollBar = unpacker.NextByte();
            rearAntiRollBar = unpacker.NextByte();
            frontSuspensionHeight = unpacker.NextByte();
            rearSuspensionHeight = unpacker.NextByte();
            brakePressure = unpacker.NextByte();
            brakeBias = unpacker.NextByte();
            tyrePressures = new TyreData<float>()
            {
                rearLeft = unpacker.NextFloat(),
                rearRight = unpacker.NextFloat(),
                frontLeft = unpacker.NextFloat(),
                frontRight = unpacker.NextFloat()
            };
            ballast = unpacker.NextByte();
            fuelLoad = unpacker.NextFloat();
        }
    }
}
