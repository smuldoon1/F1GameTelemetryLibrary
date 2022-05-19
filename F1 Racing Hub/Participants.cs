using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub
{
    public class Participants
    {
        public ulong SessionId { get; set; }

        public byte DriverId { get; set; }

        public string Name { get; set; }

        public byte TeamId { get; set; }

        public byte Nationality { get; set; }

        public byte RaceNumber { get; set; }

        public Participants()
        {
            SessionId = 0;
            DriverId = 0;
            Name = "NONAME";
            TeamId = 0;
            Nationality = 0;
            RaceNumber = 0;
        }
    }
}
