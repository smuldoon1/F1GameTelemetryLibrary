using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1RacingHub
{
    public class LapHistory
    {
        public ulong SessionId { get; set; }

        public byte CarIndex { get; set; }

        public Guid Id { get; set; }

        public byte LapNumber { get; set; }

        public uint LapTime { get; set; }

        public ushort SectorOneTime { get; set; }

        public ushort SectorTwoTime { get; set; }

        public ushort SectorThreeTime { get; set; }

        public LapHistory()
        {
            SessionId = 0;
            CarIndex = 0;
            Id = Guid.NewGuid();
            LapNumber = 0;
            LapTime = 0;
            SectorOneTime = 0;
            SectorTwoTime = 0;
            SectorThreeTime = 0;
        }
    }
}
