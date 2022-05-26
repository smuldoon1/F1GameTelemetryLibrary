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
    public class RacingHubListener
    {
        public static Label? testLabel;

        public RacingHubListener()
        {
            var listener = new UdpListener(IPAddress.Any, 20777);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IListener).IsAssignableFrom(p) && !p.IsInterface);
            foreach (var type in types)
            {
#pragma warning disable CS8604
                var obj = Activator.CreateInstance(Type.GetType(type.FullName), listener);
#pragma warning restore CS8604
                type.InvokeMember("Start", System.Reflection.BindingFlags.InvokeMethod, null, obj, Array.Empty<object>());
            }
        }
    }
}