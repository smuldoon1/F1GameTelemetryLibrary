namespace F1GameTelemetry_2021
{
    /// <summary>
    /// Motion data for a particular car.
    /// </summary>
    public partial class CarMotionData : IPacketStruct
    {
        /// <summary>
        /// Position in world space.
        /// </summary>
        public Vector3<float> WorldPosition { get { return worldPosition; } }

        /// <summary>
        /// Velocity in world space.
        /// </summary>
        public Vector3<float> WorldVelocity { get { return worldVelocity; } }

        /// <summary>
        /// Normalised forward direction in world space.
        /// </summary>
        public Vector3<short> WorldForwardDirection { get { return worldForwardDirection; } }

        /// <summary>
        /// Normalised right direction in world space.
        /// </summary>
        public Vector3<short> WorldRightDirection { get { return worldRightDirection; } }

        /// <summary>
        /// Lateral G-force component.
        /// </summary>
        public float GForceLateral { get { return gForceLateral; } }

        /// <summary>
        /// Longitudinal G-force component.
        /// </summary>
        public float GForceLongitudinal { get { return gForceLongitudinal; } }

        /// <summary>
        /// Vertical G-force component.
        /// </summary>
        public float GForceVertical { get { return gForceVertical; } }

        /// <summary>
        /// Yaw angle in radians.
        /// </summary>
        public float Yaw { get { return yaw; } }

        /// <summary>
        /// Pitch angle in radians.
        /// </summary>
        public float Pitch { get { return pitch; } }

        /// <summary>
        /// Roll angle in radians.
        /// </summary>
        public float Roll { get { return roll; } }
    }
}
