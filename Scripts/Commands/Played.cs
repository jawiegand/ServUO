using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Commands
{
    /// <summary>
    /// Displays the callers play time for the mobile.
    /// </summary>
    class Played
    {
        public static void Initialize()
        {
            CommandSystem.Register("Played", AccessLevel.Player, new CommandEventHandler(OnCommand));
        }

        private static void OnCommand(CommandEventArgs e)
        {
            Mobile senderMob = e.Mobile;
            if (senderMob != null && senderMob is PlayerMobile)
            {
                TimeSpan gameTime = ((PlayerMobile)senderMob).GameTime;

                string day = gameTime.Days == 1 ? "Day" : "Days";
                string hour = gameTime.Hours == 1 ? "Hour" : "Hours";
                string minute = gameTime.Minutes == 1 ? "Minute" : "Minutes";

                string playTime = String.Format("{0} {1}, {2} {3}, {4} {5}",
                    day,
                    gameTime.Days,
                    hour,
                    gameTime.Hours,
                    minute,
                    gameTime.Minutes);
                senderMob.SendMessage(playTime);
            }
        }
    }
}
