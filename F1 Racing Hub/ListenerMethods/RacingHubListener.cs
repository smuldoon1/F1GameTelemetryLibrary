using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using F1GameTelemetry_2021;

namespace F1_Racing_Hub
{
    public partial class RacingHubListener
    {
        private UdpListener listener;

        public RacingHubListener()
        {
            listener = new UdpListener(IPAddress.Any, 20777);

            AddParticipantMethods();
            AddLapsMethods();
            AddSessionMethods();
            AddEventMethods();
        }
    }
}