using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary.Utils
{
    /// <summary>
    /// Struct for storing data about each wheel or brake on the car.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct TyreData<T>
    {
        public T rearLeft;
        public T rearRight;
        public T frontLeft;
        public T frontRight;

        public TyreData(T rearLeft, T rearRight, T frontLeft, T frontRight)
        {
            this.rearLeft = rearLeft;
            this.rearRight = rearRight;
            this.frontLeft = frontLeft;
            this.frontRight = frontRight;
        }
    }
}
