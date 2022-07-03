namespace F1GameTelemetry_2021
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
                case FASTEST_LAP:
                    return new FastestLap(unpacker);
                case RETIREMENT:
                    return new Retirement(unpacker);
                case TEAMMATE_IN_PITS:
                    return new TeammateInPits(unpacker);
                case RACE_WINNER:
                    return new RaceWinner(unpacker);
                case PENALTY_ISSUED:
                    return new Penalty(unpacker);
                case SPEED_TRAP_TRIGGERED:
                    return new SpeedTrap(unpacker);
                case START_LIGHTS:
                    return new StartLights(unpacker);
                case DRIVE_THROUGH_SERVED:
                    return new DriveThroughPenaltyServed(unpacker);
                case STOP_GO_SERVED:
                    return new StopGoPenaltyServed(unpacker);
                case FLASHBACK:
                    return new Flashback(unpacker);
                case BUTTON_STATUS:
                    return new Buttons(unpacker);
            }
            unpacker.Dump(12);
            return null;
        }

        // Event string codes
        public const string SESSION_STARTED = "SSTA";
        public const string SESSION_ENDED = "SEND";
        public const string FASTEST_LAP = "FTLP";
        public const string RETIREMENT = "RTMT";
        public const string DRS_ENABLED = "DRSE";
        public const string DRS_DISABLED = "DRSD";
        public const string TEAMMATE_IN_PITS = "TMPT";
        public const string CHEQUERED_FLAG = "CHQF";
        public const string RACE_WINNER = "RCWN";
        public const string PENALTY_ISSUED = "PENA";
        public const string SPEED_TRAP_TRIGGERED = "SPTP";
        public const string START_LIGHTS = "STLG";
        public const string LIGHTS_OUT = "LGOT";
        public const string DRIVE_THROUGH_SERVED = "DTSV";
        public const string STOP_GO_SERVED = "SGSV";
        public const string FLASHBACK = "FLBK";
        public const string BUTTON_STATUS = "BUTN";
    }
}
