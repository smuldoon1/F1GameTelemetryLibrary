﻿using F1GameTelemetryLibrary.Packets;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Motion packet gives stores physics data for all cars. There is additional data available for the player car.
    /// </summary>
    internal class MotionPacket : F1Packet, IPacket
    {
        /// <summary>
        /// Array of car motion data.
        /// </summary>
        CarMotionData[] carMotionData = new CarMotionData[F1Globals.MAX_CARS];

        TyreData<float> suspensionPosition;
        TyreData<float> suspensionVeloctity;
        TyreData<float> suspensionAcceleration;
        TyreData<float> wheelSpeed;
        TyreData<float> wheelSlip;
        Vector3<float> localVelocity;
        Vector3<float> angularVelocity;
        Vector3<float> angularAcceleration;

        /// <summary>
        /// Front wheel angle in radians.
        /// </summary>
        float frontWheelsAngle;

        public void Unpack(byte[] packedData)
        {
            Unpacker unpacker = new Unpacker(packedData);

            for (int i = 0; i < carMotionData.Length; i++)
            {
                carMotionData[i].Unpack(unpacker);
            }
            suspensionPosition = new TyreData<float>()
            {
                rearRight = unpacker.NextFloat(),
                rearLeft = unpacker.NextFloat(),
                frontRight = unpacker.NextFloat(),
                frontLeft = unpacker.NextFloat()
            };
            suspensionVeloctity = new TyreData<float>()
            {
                rearRight = unpacker.NextFloat(),
                rearLeft = unpacker.NextFloat(),
                frontRight = unpacker.NextFloat(),
                frontLeft = unpacker.NextFloat()
            };
            suspensionAcceleration = new TyreData<float>()
            {
                rearRight = unpacker.NextFloat(),
                rearLeft = unpacker.NextFloat(),
                frontRight = unpacker.NextFloat(),
                frontLeft = unpacker.NextFloat()
            };
            wheelSpeed = new TyreData<float>()
            {
                rearRight = unpacker.NextFloat(),
                rearLeft = unpacker.NextFloat(),
                frontRight = unpacker.NextFloat(),
                frontLeft = unpacker.NextFloat()
            };
            wheelSlip = new TyreData<float>()
            {
                rearRight = unpacker.NextFloat(),
                rearLeft = unpacker.NextFloat(),
                frontRight = unpacker.NextFloat(),
                frontLeft = unpacker.NextFloat()
            };
            localVelocity = new Vector3<float>()
            {
                x = unpacker.NextFloat(),
                y = unpacker.NextFloat(),
                z = unpacker.NextFloat()
            };
            angularVelocity = new Vector3<float>()
            {
                x = unpacker.NextFloat(),
                y = unpacker.NextFloat(),
                z = unpacker.NextFloat()
            };
            angularAcceleration = new Vector3<float>()
            {
                x = unpacker.NextFloat(),
                y = unpacker.NextFloat(),
                z = unpacker.NextFloat()
            };
            frontWheelsAngle = unpacker.NextFloat();
        }
    }
}
