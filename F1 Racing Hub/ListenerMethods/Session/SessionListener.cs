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
        public Session? currentSession;

        public void AddSessionMethods()
        {
            listener.Subscribe(HandleSessionData);
        }

        public void HandleSessionData(SessionPacket sessionPacket)
        {
            Sql.Execute(
                    $"BEGIN " +
                        $"IF NOT EXISTS(SELECT id " +
                        $"FROM [F1App].[dbo].[Sessions] " +
                        $"WHERE id = { sessionPacket.SessionUID.ToSql() }) " +
                        $"BEGIN " +
                            $"INSERT INTO [F1App].[dbo].[Sessions] " +
                            $"(id, type, trackId) " +
                            $"VALUES({ sessionPacket.SessionUID.ToSql() }, { (byte)sessionPacket.SessionType }, { sessionPacket.TrackId }) " +
                        $"END " +
                    $"END");
        }
    }
}