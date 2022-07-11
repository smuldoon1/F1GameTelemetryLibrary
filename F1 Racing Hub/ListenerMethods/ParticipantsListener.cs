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
        public void AddParticipantMethods()
        {
            listener.Subscribe(HandleParticipantsData);
        }

        public void HandleParticipantsData(ParticipantsPacket participantsPacket)
        {
            for (byte i = 0; i < participantsPacket.Participants.Length; i++)
            {
                ParticipantData data = participantsPacket.Participants[i];
                if (data.RaceNumber > 0)
                {
                    Sql.Execute(
                    $"BEGIN " +
                        $"IF NOT EXISTS(SELECT sessionId, carIndex " +
                        $"FROM [F1App].[dbo].[Participants] " +
                        $"WHERE sessionId = { participantsPacket.SessionUID.ToSql() } " +
                        $"AND carIndex = { i }) " +
                        $"BEGIN " +
                            $"INSERT INTO [F1App].[dbo].[Participants] " +
                            $"(sessionId, carIndex, aiDriverId, name, teamId, nationalityId, raceNumber) " +
                            $"VALUES({ participantsPacket.SessionUID.ToSql() }, { i }, { data.DriverId }, '{ data.Name }', { data.TeamId }, { data.NationalityId }, { data.RaceNumber }) " +
                        $"END " +
                    $"END");
                }
            }
        }
    }
}