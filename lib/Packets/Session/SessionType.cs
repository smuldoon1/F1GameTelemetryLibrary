namespace F1GameTelemetry_2021
{
    public enum SessionType : byte
    {
        UNKNOWN = 0,
        PRACTICE_1 = 1,
        PRACTICE_2 = 2,
        PRACTICE_3 = 3,
        SHORT_PRACTICE = 4,
        QUALIFYING_1 = 5,
        QUALIFYING_2 = 6,
        QUALIFYING_3 = 7,
        SHORT_QUALIFYING = 8,
        ONE_SHOT_QUALIFYING = 9,
        RACE = 10,
        RACE_TWO = 11,
        RACE_THREE = 12,
        TIME_TRIAL = 13
    }

    public static class SessionTypeExtensions
    {
        public static string ToString(this SessionType sessionType)
        {
            switch (sessionType)
            {
                case SessionType.UNKNOWN:
                    return "Unknown";
                case SessionType.PRACTICE_1:
                    return "FP11";
                case SessionType.PRACTICE_2:
                    return "FP2";
                case SessionType.PRACTICE_3:
                    return "FP3";
                case SessionType.SHORT_PRACTICE:
                    return "Practice";
                case SessionType.QUALIFYING_1:
                    return "Q1";
                case SessionType.QUALIFYING_2:
                    return "Q2";
                case SessionType.QUALIFYING_3:
                    return "Q3";
                case SessionType.SHORT_QUALIFYING:
                    return "Qualifying";
                case SessionType.ONE_SHOT_QUALIFYING:
                    return "OSQ";
                case SessionType.RACE:
                    return "Race";
                case SessionType.RACE_TWO:
                    return "Race 2";
                case SessionType.RACE_THREE:
                    return "Race 3";
                case SessionType.TIME_TRIAL:
                    return "Time Trial";
                default:
                    return "Invalid";
            }
        }
    }
}
