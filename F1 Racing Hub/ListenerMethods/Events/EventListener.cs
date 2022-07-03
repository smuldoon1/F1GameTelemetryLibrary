using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1GameTelemetry_2021;

namespace F1_Racing_Hub
{
    public partial class RacingHubListener
    {
        public void AddEventMethods()
        {
            listener.Subscribe(HandleEvent);
        }

        public void HandleEvent(EventPacket eventPacket)
        {
            if (eventPacket.EventCode == EventDataDetails.BUTTON_STATUS)
            {
                if (eventPacket.EventDataDetails is Buttons buttons)
                    Console.WriteLine(ButtonsToStringPS4(buttons.ButtonStatus));
            }
        }

        public static string ButtonsToStringPS4(ButtonFlags flags)
        {
            var buttons = new List<string>();
            if (flags.HasFlag(ButtonFlags.BUTTON_DOWN))
                buttons.Add("X");
            if (flags.HasFlag(ButtonFlags.BUTTON_UP))
                buttons.Add("Triangle");
            if (flags.HasFlag(ButtonFlags.BUTTON_RIGHT))
                buttons.Add("Circle");
            if (flags.HasFlag(ButtonFlags.BUTTON_LEFT))
                buttons.Add("Square");
            if (flags.HasFlag(ButtonFlags.LEFT_STICK_LEFT))
                buttons.Add("Left Stick Left");
            if (flags.HasFlag(ButtonFlags.LEFT_STICK_RIGHT))
                buttons.Add("Left Stick Right");
            if (flags.HasFlag(ButtonFlags.LEFT_STICK_UP))
                buttons.Add("Left Stick Up");
            if (flags.HasFlag(ButtonFlags.LEFT_STICK_DOWN))
                buttons.Add("Left Stick Down");
            if (flags.HasFlag(ButtonFlags.OPTIONS))
                buttons.Add("Options");
            if (flags.HasFlag(ButtonFlags.LEFT_BUMPER))
                buttons.Add("L1");
            if (flags.HasFlag(ButtonFlags.RIGHT_BUMPER))
                buttons.Add("R1");
            if (flags.HasFlag(ButtonFlags.LEFT_TRIGGER))
                buttons.Add("L2");
            if (flags.HasFlag(ButtonFlags.RIGHT_TRIGGER))
                buttons.Add("R2");
            if (flags.HasFlag(ButtonFlags.LEFT_STICK_CLICK))
                buttons.Add("L3");
            if (flags.HasFlag(ButtonFlags.RIGHT_STICK_CLICK))
                buttons.Add("R3");
            if (flags.HasFlag(ButtonFlags.RIGHT_STICK_LEFT))
                buttons.Add("Right Stick Left");
            if (flags.HasFlag(ButtonFlags.RIGHT_STICK_RIGHT))
                buttons.Add("Right Stic Right");
            if (flags.HasFlag(ButtonFlags.RIGHT_STICK_UP))
                buttons.Add("Right Stick Up");
            if (flags.HasFlag(ButtonFlags.RIGHT_STICK_DOWN))
                buttons.Add("Right Stick Down");
            if (flags.HasFlag(ButtonFlags.SPECIAL))
                buttons.Add("Touch Pad");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_1))
                buttons.Add("Action 1");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_2))
                buttons.Add("Action 2");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_3))
                buttons.Add("Action 3");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_4))
                buttons.Add("Action 4");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_5))
                buttons.Add("Action 5");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_6))
                buttons.Add("Action 6");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_7))
                buttons.Add("Action 7");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_8))
                buttons.Add("Action 8");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_9))
                buttons.Add("Action 9");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_10))
                buttons.Add("Action 10");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_11))
                buttons.Add("Action 11");
            if (flags.HasFlag(ButtonFlags.UDP_ACTION_12))
                buttons.Add("Action 12");
            if (buttons.Count == 0)
                return "No buttons pressed";
            return string.Join(", ", buttons);
        }
    }
}
