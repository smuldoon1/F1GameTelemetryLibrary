using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub
{
    public class Session
    {
        public ulong SessionId { get; set; }

        public byte Type { get; set; }

        public sbyte TrackId { get; set; }

        public Session()
        {
            SessionId = 0;
            Type = 0;
            TrackId = -1;
        }
    }
}
