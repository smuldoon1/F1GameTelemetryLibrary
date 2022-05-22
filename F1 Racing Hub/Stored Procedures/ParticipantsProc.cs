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
            StoredProcedure.CallProcedure("CreateParticipant",
                ("sessionId", participants.SessionId),
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
            SqlDataReader reader = StoredProcedure.CallProcedure("CheckParticipantExists",
                ("sessionId", participant.SessionId),
                ("carIndex", participant.CarIndex)
            );
            return reader.GetBoolean(0);
        }
    }
}
