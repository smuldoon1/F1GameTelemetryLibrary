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
    public partial class RacingHubListener
    {
        public Session? currentSession;

        public void AddSessionMethods()
        {
            listener.Subscribe(HandleSessionData);
        }

        public void HandleSessionData(SessionPacket sessionPacket)
        {
            currentSession = new Session()
            {
                SessionId = sessionPacket.SessionUID,
                Type = (byte)sessionPacket.SessionType,
                TrackId = sessionPacket.TrackId
            };
            if (!SessionProc.CheckSessionExists(currentSession))
                SessionProc.CreateSession(currentSession);
        }
    }
}