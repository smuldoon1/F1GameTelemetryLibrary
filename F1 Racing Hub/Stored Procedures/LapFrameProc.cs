using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub.Stored_Procedures
{
    internal static class LapFrameProc
    {
        public static void CreateLapFrame(LapFrame frame)
        {
            StoredProcedure.CallProcedure("[F1App].[dbo].[CreateLapFrame]",
                ("lapId", frame.LapId),
                ("distance", frame.Distance),
                ("speed", frame.Speed.ToSql()),
                ("throttle", frame.Throttle),
                ("steer", frame.Steer),
                ("brake", frame.Brake),
                ("gear", frame.Gear.ToSql())
            );
        }
    }
}
