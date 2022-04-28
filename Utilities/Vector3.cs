using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
{
    /// <summary>
    /// Generic all-purpose 3-dimensional vector struct.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Vector3<T>
    {
        public T x;
        public T y;
        public T z;

        public Vector3(T x, T y, T z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
