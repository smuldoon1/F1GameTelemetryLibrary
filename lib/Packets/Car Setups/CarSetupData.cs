namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Car setup values for a particular car.
    /// </summary>
    public partial class CarSetupData  : IPacketStruct
    {
        /// <summary>
        /// Front wing aero angle.
        /// </summary>
        public byte FrontWing { get { return frontWing; } }

        /// <summary>
        /// Rear wing aero angle.
        /// </summary>
        public byte RearWing { get { return rearWing; } }

        /// <summary>
        /// Differential adjustment on throttle as a percentage.
        /// </summary>
        public byte OnThrottle { get { return onThrottle; } }

        /// <summary>
        /// Differential adjustment off throttle as a percentage.
        /// </summary>
        public byte OffThrottle { get { return offThrottle; } }

        /// <summary>
        /// Front camber angle of suspension geometry.
        /// </summary>
        public float FrontCamber { get { return frontCamber; } }

        /// <summary>
        /// Rear camber angle of suspension geometry.
        /// </summary>
        public float RearCamber { get { return rearCamber; } }

        /// <summary>
        /// Front toe angle of suspension geometry.
        /// </summary>
        public float FrontToe { get { return frontToe; } }

        /// <summary>
        /// Rear toe angle of suspension geometry.
        /// </summary>
        public float RearToe { get { return rearToe; } }

        /// <summary>
        /// Front suspension amount.
        /// </summary>
        public byte FrontSuspension { get { return frontSuspension; } }

        /// <summary>
        /// Rear suspension amount.
        /// </summary>
        public byte RearSuspension { get { return rearSuspension; } }

        /// <summary>
        /// Front anti-roll bar amount.
        /// </summary>
        public byte FrontAntiRollBar { get { return frontAntiRollBar; } }

        /// <summary>
        /// Rear anti-roll bar amount.
        /// </summary>
        public byte RearAntiRollBar { get { return rearAntiRollBar; } }

        /// <summary>
        /// Front ride height.
        /// </summary>
        public byte FrontSuspensionHeight { get { return frontSuspensionHeight; } }

        /// <summary>
        /// Rear ride height.
        /// </summary>
        public byte RearSuspensionHeight { get { return rearSuspensionHeight; } }

        /// <summary>
        /// Brake pressure as a percentage.
        /// </summary>
        public byte BrakePressure { get { return brakePressure; } }

        /// <summary>
        /// Brake bias as a percentage.
        /// </summary>
        public byte BrakeBias { get { return brakeBias; } }

        /// <summary>
        /// Tyre pressures in pounds per square inch.
        /// </summary>
        public TyreData<float> TyrePressures { get { return tyrePressures; } }

        /// <summary>
        /// The amount of ballast.
        /// </summary>
        public byte Ballast { get { return ballast; } }

        /// <summary>
        /// The amount of fuel in litres.
        /// </summary>
        public float FuelLoad { get { return fuelLoad; } }
    }
}
