namespace F1GameTelemetry_2021
{
    public enum PacketId : byte
    {
        MOTION = 0,
        SESSION = 1,
        LAP_DATA = 2,
        EVENT = 3,
        PARTICIPANTS = 4,
        CAR_SETUPS = 5,
        CAR_TELEMETRY = 6,
        CAR_STATUS = 7,
        FINAL_CLASSIFICATION = 8,
        LOBBY_INFO = 9,
        CAR_DAMAGE = 10,
        SESSION_HISTORY = 11
    }
}
