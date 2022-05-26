using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using F1GameTelemetry;
using F1_Racing_Hub.Stored_Procedures;

namespace F1_Racing_Hub
{
    public abstract class ListenerObject
    {
        public UdpListener listener;

        public ListenerObject(ref UdpListener listener)
        {
            this.listener = listener;
        }
    }
}