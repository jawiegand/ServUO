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
                string playTime = String.Format("Day(s) {0} Hour(s) {1} Minute(s) {2}",
                    gameTime.Days,
                    gameTime.Hours,
                    gameTime.Minutes);
                senderMob.SendMessage(playTime);
            }
        }
    }
}
