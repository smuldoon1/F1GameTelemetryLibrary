namespace F1GameTelemetry_2021
{
    [Flags]
    public enum LapValidityFlags : byte
    {
        LAP = 0x01,
        SECTOR_ONE = 0x02,
        SECTOR_TWO = 0x04,
        SECTOR_THREE = 0x08
    }
}
