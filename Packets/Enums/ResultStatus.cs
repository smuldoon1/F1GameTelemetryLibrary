namespace F1GameTelemetryLibrary.Enums
{
    public enum ResultStatus : byte
    {
        INVALID = 0,
        INACTIVE = 1,
        ACTIVE = 2,
        FINISHED = 3,
        DID_NOT_FINISH = 4,
        DISQUALIFIED = 5,
        NOT_CLASSIFIED = 6,
        RETIRED = 7
    }
}
