namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Motion packet gives stores physics data for all cars. There is additional data available for the player car.
    /// </summary>
    public partial class MotionPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car motion data.
        /// </summary>
        public CarMotionData[] CarMotionData { get { return carMotionData; } }

        public TyreData<float> SuspensionPosition { get { return suspensionPosition; } }
        public TyreData<float> SuspensionVeloctity { get { return suspensionVeloctity; } }
        public TyreData<float> SuspensionAcceleration { get { return suspensionAcceleration; } }
        public TyreData<float> WheelSpeed { get { return wheelSpeed; } }
        public TyreData<float> WheelSlip { get { return wheelSlip; } }
        public Vector3<float> LocalVelocity { get { return localVelocity; } }
        public Vector3<float> AngularVelocity { get { return angularVelocity; } }
        public Vector3<float> AngularAcceleration { get { return angularAcceleration; } }

        /// <summary>
        /// Front wheel angle in radians.
        /// </summary>
        public float FrontWheelsAngle { get { return frontWheelsAngle; } }
    }
}
