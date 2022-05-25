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
        private Participant[] participants = new Participant[22];

        public void AddParticipantMethods()
        {
            for (int i = 0; i < participants.Length; i++)
                participants[i] = new Participant();

            listener.Subscribe(HandleParticipantsData);
        }

        public void HandleParticipantsData(ParticipantsPacket participantsPacket)
        {
            for (byte i = 0; i < participantsPacket.Participants.Length; i++)
            {
                participants[i].SessionId = participantsPacket.SessionUID;
                participants[i].CarIndex = i;
                participants[i].DriverId = participantsPacket.Participants[i].DriverId;
                participants[i].Name = participantsPacket.Participants[i].Name;
                participants[i].TeamId = participantsPacket.Participants[i].TeamId;
                participants[i].Nationality = participantsPacket.Participants[i].NationalityId;
                participants[i].RaceNumber = participantsPacket.Participants[i].RaceNumber;
                if (participants[i].RaceNumber > 0 && !ParticipantsProc.CheckParticipantExists(participants[i]))
                {
                    ParticipantsProc.CreateParticipant(participants[i]);
                }
            }
        }
    }
}