using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary
{
    internal static class F1Globals
    {
        /// <summary>
        /// Maximum number of cars in a session.
        /// </summary>
        public const int MAX_CARS = 22;

        /// <summary>
        /// Maximum number of marshall zones at a track.
        /// </summary>
        public const int MAX_MARSHALL_ZONES = 21;

        /// <summary>
        /// Total number of weather forecast samples that may be available.
        /// </summary>
        public const int TOTAL_WEATHER_FORECAST_SAMPLES = 56;

        /// <summary>
        /// Maximum number of tyre stints history data that is stored.
        /// </summary>
        public const int MAX_TYRE_STINTS_HISTORY_DATA = 8;

        /// <summary>
        /// Maximum number of lap history data that is stored.
        /// </summary>
        public const int MAX_LAP_HISTORY_DATA = 100;
    }
}
