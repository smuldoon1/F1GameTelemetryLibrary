using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1RacingHub
{
    public class LapFrame
    {
        public Guid LapId { get; set; }

        public ulong SessionId { get; set; }

        public byte CarIndex { get; set; }

        public byte LapNumber { get; set; }

        public float Distance { get; set; }

        public ushort Speed { get; set; }

        public float Throttle { get; set; }

        public float Steer { get; set; }

        public float Brake { get; set; }

        public sbyte Gear { get; set; }
    }
}
