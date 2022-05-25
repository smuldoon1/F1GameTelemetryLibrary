using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub.Stored_Procedures
{
    internal static class SessionProc
    {
        public static void CreateSession(Session session)
        {
            StoredProcedure.CallProcedure("[F1App].[dbo].[CreateSession]",
                ("sessionId", session.SessionId.ToSql()),
                ("sessionType", session.Type),
                ("trackId", session.TrackId.ToSql())
            );
        }

        public static bool CheckSessionExists(Session session)
        {
            int intValue = (int)StoredProcedure.CallProcedure("[F1App].[dbo].[CheckSessionExists]",
                ("sessionId", session.SessionId.ToSql())
            );
            if (intValue == 0) return false;
            return true;
        }
    }
}
