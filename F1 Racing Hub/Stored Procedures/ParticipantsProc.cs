using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub.Stored_Procedures
{
    internal static class ParticipantsProc
    {
        public static void CreateParticipant(Participant participants)
        {
            StoredProcedure.CallProcedure("[F1App].[dbo].[CreateParticipant]",
                ("sessionId", participants.SessionId.MapToLong()),
                ("carIndex", participants.CarIndex),
                ("aiDriverId", participants.DriverId),
                ("name", participants.Name),
                ("teamId", participants.TeamId),
                ("nationalityId", participants.Nationality),
                ("raceNumber", participants.RaceNumber)
            );
        }

        public static bool CheckParticipantExists(Participant participant)
        {
            int intValue = (int)StoredProcedure.CallProcedure("[F1App].[dbo].[CheckParticipantExists]",
                ("sessionId", participant.SessionId.MapToLong()),
                ("carIndex", participant.CarIndex)
            );
            if (intValue == 0) return false;
            return true;
        }
    }
}
