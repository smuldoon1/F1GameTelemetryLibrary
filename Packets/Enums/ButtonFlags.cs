namespace F1GameTelemetryLibrary.Events.Enums
{
    [Flags]
    public enum ButtonFlags : uint
    {
        CROSS = 0x00000001,
        TRIANGLE = 0x00000002,
        CIRCLE = 0x00000004,
        SQUARE = 0x00000008,
        D_PAD_LEFT = 0x00000010,
        D_PAD_RIGHT = 0x00000020,
        D_PAD_UP = 0x00000040,
        D_PAD_DOWN = 0x00000080,
        OPTIONS = 0x00000100,
        L1 = 0x00000200,
        R1 = 0x00000400,
        L2 = 0x00000800,
        R2 = 0x00001000,
        LEFT_STICK_CLICK = 0x00002000,
        RIGHT_STICK_CLICK = 0x00004000,
        RIGHT_STICK_LEFT = 0x00008000,
        RIGHT_STICK_RIGHT = 0x00010000,
        RIGHT_STICK_UP = 0x00020000,
        RIGHT_STICK_DOWN = 0x00040000,
        SPECIAL = 0x000800000
    }
}
