using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub.Stored_Procedures
{
    internal static class LapHistoryProc
    {
        public static void CreateLapHistoryData(LapHistoryData lapData)
        {
            StoredProcedure.CallProcedure("[F1App].[dbo].[CreateLapData]",
                ("sessionId", lapData.SessionId.ToSql()),
                ("carIndex", lapData.CarIndex),
                ("id", lapData.Id),
                ("number", lapData.LapNumber),
                ("time", lapData.LapTime.ToSql()),
                ("sectorOneTime", lapData.SectorOneTime.ToSql()),
                ("sectorTwoTime", lapData.SectorTwoTime.ToSql()),
                ("sectorThreeTime", lapData.SectorThreeTime.ToSql())
            );
        }

        public static bool CheckLapHistoryDataExists(LapHistoryData lapData)
        {
            int intValue = (int)StoredProcedure.CallProcedure("[F1App].[dbo].[CheckLapDataExists]",
                ("lapId", lapData.Id)
            );
            if (intValue == 0) return false;
            return true;
        }
    }
}
