namespace F1GameTelemetry
{
    /// <summary>
    /// Motion data for a particular car.
    /// </summary>
    partial class CarMotionData : IPacketStruct
    {
        /// <summary>
        /// Position in world space.
        /// </summary>
        Vector3<float> worldPosition;

        /// <summary>
        /// Velocity in world space.
        /// </summary>
        Vector3<float> worldVelocity;

        /// <summary>
        /// Normalised forward direction in world space.
        /// </summary>
        Vector3<short> worldForwardDirection;

        /// <summary>
        /// Normalised right direction in world space.
        /// </summary>
        Vector3<short> worldRightDirection;

        /// <summary>
        /// Lateral G-force component.
        /// </summary>
        float gForceLateral;

        /// <summary>
        /// Longitudinal G-force component.
        /// </summary>
        float gForceLongitudinal;

        /// <summary>
        /// Vertical G-force component.
        /// </summary>
        float gForceVertical;

        /// <summary>
        /// Yaw angle in radians.
        /// </summary>
        float yaw;

        /// <summary>
        /// Pitch angle in radians.
        /// </summary>
        float pitch;

        /// <summary>
        /// Roll angle in radians.
        /// </summary>
        float roll;

        public void Unpack(Unpacker unpacker)
        {
            worldPosition = new Vector3<float>()
            {
                x = unpacker.NextFloat(),
                y = unpacker.NextFloat(),
                z = unpacker.NextFloat()
            };
            worldVelocity = new Vector3<float>()
            {
                x = unpacker.NextFloat(),
                y = unpacker.NextFloat(),
                z = unpacker.NextFloat()
            };
            worldForwardDirection = new Vector3<short>()
            {
                x = unpacker.NextShort(),
                y = unpacker.NextShort(),
                z = unpacker.NextShort()
            };
            worldRightDirection = new Vector3<short>()
            {
                x = unpacker.NextShort(),
                y = unpacker.NextShort(),
                z = unpacker.NextShort()
            };
            gForceLateral = unpacker.NextFloat();
            gForceLongitudinal = unpacker.NextFloat();
            gForceVertical = unpacker.NextFloat();
            yaw = unpacker.NextFloat();
            pitch = unpacker.NextFloat();
            roll = unpacker.NextFloat();
        }
    }
}
