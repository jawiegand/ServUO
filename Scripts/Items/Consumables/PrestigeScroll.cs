// **********
// ServUO - PrestigeScroll.cs
// **********

using Server.Configs;
using Server.Prompts;
using System;

namespace Server.Items
{
    public class PrestigeScroll : Item
    {
        private int m_Level;
        public int Level
        {
            get
            {
                return m_Level;
            }
        }

        /// <summary>
        /// Default constructor, returns a level one Prestige Scroll
        /// </summary>
        public PrestigeScroll() : this(1)
        {
        }

        /// <summary>
        /// Ctor for creating item.
        /// </summary>
        /// <param name="level">The level (1,2,3) of the scroll</param>
        [Constructable]
        public PrestigeScroll(int level) : base(0x14F0)
        {
            Weight = 1.0;
            Name = "Prestige Scroll ";   // Mind the trailing space!
            LootType = LootType.Blessed;
            Hue = 1161;

            switch (level)
            {
                case 1:
                    Name += "I";
                    break;
                case 2:
                    Name += "II";
                    break;
                case 3:
                    Name += "III";
                    break;
                default:
                    level = 1;
                    goto case 1;
            }

            m_Level = level;
        }

        public PrestigeScroll(Serial serial) : base(serial)
        {
        }

        /// <summary>
        /// Serializes class for save.
        /// </summary>
        /// <param name="writer">Writer to storage</param>
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            // Version
            writer.Write(1);

            writer.Write(m_Level);
        }

        /// <summary>
        /// Inflates an instance from a stream.
        /// </summary>
        /// <param name="reader"></param>
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Level = reader.ReadInt();
        }

        /// <summary>
        /// Action to take when a player double clicks on the item.
        /// </summary>
        /// <param name="from">Reference to clicker</param>
        public override void OnDoubleClick(Mobile from)
        {
            if (from == null)
                return;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            if (CanUse(from.SkillsTotal, from.PrestigeLevel, from.SendMessage))
            {
                from.PrestigeLevel = m_Level;

                #region Animation
                // Same animation as PowerScroll
                Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0, 0, 0, 0, 0, 5060, 0);
                Effects.PlaySound(from.Location, from.Map, 0x243);

                Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(from.X - 6, from.Y - 6, from.Z + 15), from.Map), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(from.X - 4, from.Y - 6, from.Z + 15), from.Map), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(from.X - 6, from.Y - 4, from.Z + 15), from.Map), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);

                Effects.SendTargetParticles(from, 0x375A, 35, 90, 0x00, 0x00, 9502, (EffectLayer)255, 0x100);
                #endregion


                from.SendMessage(String.Format("You've reached Prestige Level {0}!", from.PrestigeLevel));
                from.SendMessage(String.Format("Skill Cap: {0:0.0}", from.SkillsCap / 10.0));

                switch (m_Level)
                {
                    case 1:
                        from.SendMessage(String.Format("You can now use Scrolls Of Power up to skill {0}",
                            PrestigeLevelConfig.LevelOnePowerScrollMax));
                        from.SendMessage(String.Format("The skill gain difficulty has increased by {0}x of base",
                            PrestigeLevelConfig.LevelOneDifficulty));
                        break;
                    case 2:
                        from.SendMessage(String.Format("You can now use Scrolls Of Power up to skill {0}",
                            PrestigeLevelConfig.LevelTwoPowerScrollMax));
                        from.SendMessage(String.Format("The skill gain difficulty has increased by {0}x of base",
                            PrestigeLevelConfig.LevelTwoDifficulty));
                        from.SendMessage("Base Luck 150");
                        break;
                    case 3:
                        from.SendMessage("You can now use any Scrolls Of Power");
                        from.SendMessage(String.Format("The skill gain difficulty has increased by {0}x to {1}x of base",
                            PrestigeLevelConfig.MaxOneDifficulty, PrestigeLevelConfig.MaxDifficulty));
                        from.SendMessage("Base Luck 150");
                        from.SendMessage(String.Format("Stat Cap: {0}", from.StatCap));
                        from.SendMessage("Hits/Mana/Stam all increased by a total of 10%");
                        break;
                }
                Delete();
            }
        }

        private bool CanUse(int skillTotal, int prestigeLevel, Action<string> sendMessage)
        {
            if (!PrestigeLevelConfig.IsEnabled)
            {
                sendMessage("You cannot use this. This feature is not enabled on this shard.");
                return false;
            }

            if (prestigeLevel == m_Level - 1)
            {
                int skillNeeded;
                switch (m_Level)
                {
                    case 1:
                        skillNeeded = PrestigeLevelConfig.BaseSkillCap;
                        break;
                    case 2:
                        skillNeeded = PrestigeLevelConfig.LevelOneSkillCap;
                        break;
                    case 3:
                        skillNeeded = PrestigeLevelConfig.LevelTwoSkillCap;
                        break;
                    default:
                        return false;
                }

                if (skillTotal >= skillNeeded)
                {
                    return true;
                }
                else
                {
                    sendMessage(String.Format("You cannot use this. You need to gain {0:0.0} more skill.", (skillNeeded - skillTotal)/10.0));
                }
            }
            else
            {
                sendMessage(String.Format("You cannot use this. Your prestige level must be {0}.", m_Level - 1));
            }

            return false;
        }

        private class WarningPrompt : Prompt
        {
            private readonly PrestigeScroll m_PrestigeScroll;
            public WarningPrompt(PrestigeScroll scroll)
            {
                m_PrestigeScroll = scroll;
            }

            public override void OnResponse(Mobile from, string text)
            {
                if (String.Equals(text, "y", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(text, "yes", StringComparison.OrdinalIgnoreCase))
                {


                }
                else
                {
                    from.SendMessage("The scroll will not be consumed.");
                }
            }
        }
    }
}
