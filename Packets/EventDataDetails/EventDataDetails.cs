namespace F1GameTelemetry
{
    /// <summary>
    /// Superclass for details about each type of event data.
    /// </summary>
    public abstract partial class EventDataDetails
    {
        /// <summary>
        /// Returns a new instance of an EventDataDetails subclass depending on the event code given.
        /// </summary>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        public static EventDataDetails? CreateEventDataDetails(string eventCode, Unpacker unpacker)
        {
            switch (eventCode)
            {
                case "FTLP":
                    return new FastestLap(unpacker);
                case "RTMT":
                    return new Retirement(unpacker);
                case "TMPT":
                    return new TeammateInPits(unpacker);
                case "RCWN":
                    return new RaceWinner(unpacker);
                case "PENA":
                    return new Penalty(unpacker);
                case "SPTP":
                    return new SpeedTrap(unpacker);
                case "STLG":
                    return new StartLights(unpacker);
                case "DTSV":
                    return new DriveThroughPenaltyServed(unpacker);
                case "SGSV":
                    return new StopGoPenaltyServed(unpacker);
                case "FLBK":
                    return new Flashback(unpacker);
                case "BUTN":
                    return new Buttons(unpacker);
            }
            unpacker.Dump(8);
            return null;
        }
    }
}
