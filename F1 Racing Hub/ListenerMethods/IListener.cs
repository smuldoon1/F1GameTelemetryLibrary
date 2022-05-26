using F1GameTelemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub
{
    public interface IListener
    {
        void Start();

        void SessionBegin();
    }
}
