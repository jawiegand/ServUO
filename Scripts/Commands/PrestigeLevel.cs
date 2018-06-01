using Server.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Commands
{
    /// <summary>
    /// Displays the callers Prestige Level
    /// </summary>
    class PrestigeLevel
    {
        public static void Initialize()
        {
            CommandSystem.Register("PL", AccessLevel.Player, new CommandEventHandler(OnCommand));
        }

        [Usage( "Prestige Level")]
        [Description("Returns the caller's Prestige Level")]
        private static void OnCommand(CommandEventArgs e)
        {
            if (!PrestigeLevelConfig.IsEnabled)
            {
                e.Mobile.SendMessage("This server is not using the Prestige Level system.");
            }
            else
            {
                Mobile senderMob = e.Mobile;
                if (senderMob != null)
                {
                senderMob.SendMessage("Prestige Level " + senderMob.PrestigeLevel +
                    " (" + senderMob.SkillsTotal + "/" + senderMob.SkillsCap + ")");
                }
            }
        }
    }
}
