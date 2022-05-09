using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1GameTelemetryLibrary.Events
{
    /// <summary>
    /// Superclass for details about each type of event data.
    /// </summary>
    public abstract partial class EventDataDetails
    {
        abstract public void Unpack(Unpacker unpacker);

        /// <summary>
        /// Returns a new instance of an EventDataDetails subclass depending on the event code given.
        /// </summary>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        public static EventDataDetails? CreateEventDataDetails(string eventCode)
        {
            switch (eventCode)
            {
                case "FTLP":
                    return new FastestLap();
                case "RTMT":
                    return new Retirement();
                case "TMPT":
                    return new TeammateInPits();
                case "RCWN":
                    return new RaceWinner();
                case "PENA":
                    return new Penalty();
                case "SPTP":
                    return new SpeedTrap();
                case "STLG":
                    return new StartLights();
                case "DTSV":
                    return new DriveThroughPenaltyServed();
                case "SGSV":
                    return new StopGoPenaltyServed();
                case "FLBK":
                    return new Flashback();
                case "BUTN":
                    return new Buttons();
            }
            return null;
        }
    }
}
