using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub.Stored_Procedures
{
    internal static class ParticipantsProc
    {
        public static void SetParticipants(Participants[] participants)
        {
            foreach (Participants p in participants)
            {
                StoredProcedure.CallProcedure("CreateParticipant",
                    ("sessionId", p.SessionId),
                    ("carIndex", p.CarIndex),
                    ("aiDriverId", p.DriverId),
                    ("name", p.Name),
                    ("teamId", p.TeamId),
                    ("nationalityId", p.Nationality),
                    ("raceNumber", p.RaceNumber)
                );
            }
        }
    }
}
