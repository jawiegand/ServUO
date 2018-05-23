// **********
// ServUO - ScrollOfPrestige.cs
// **********

using Server.Configs;
using System;

namespace Server.Items
{
    public class ScrollOfPrestige : Item
    {
        private int m_Level;

        /// <summary>
        /// Ctor for creating item.
        /// </summary>
        /// <param name="level">The level (1,2,3) of the scroll</param>
        [Constructable]
        public ScrollOfPrestige(int level) : base(0x0E3A)
        {
            Weight = 1.0;
            Name = "Scroll of Prestige";

            switch (level)
            {
                case 1:
                    Name += " - I";
                    break;
                case 2:
                    Name += " - II";
                    break;
                case 3:
                    Name += " - III";
                    break;
                default:
                    level = 1;
                    goto case 1;
            }

            m_Level = level;
        }

        public ScrollOfPrestige(Serial serial) : base(serial)
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

            if (PrestigeLevelConfig.IsEnabled && CanUse(from.SkillsTotal, from.PrestigeLevel))
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

                switch (m_Level)
                {
                    case 1:
                        from.SendMessage("You've reached Prestige Level 1!");
                        from.SendMessage(String.Format("Skill Cap: {0}", from.SkillsCap));
                        from.SendMessage(String.Format("You can now use Scrolls Of Power up to skill {0}",
                            PrestigeLevelConfig.LevelOnePowerScrollMax));
                        from.SendMessage(String.Format("The skill gain difficulty has increased by {0}x of base",
                            PrestigeLevelConfig.LevelOneDifficulty));
                        break;
                    case 2:
                        from.SendMessage("You've reached Prestige Level 2!");
                        from.SendMessage(String.Format("Skill Cap: {0}", from.SkillsCap)); 
                        from.SendMessage(String.Format("You can now use Scrolls Of Power up to skill {0}",
                            PrestigeLevelConfig.LevelTwoPowerScrollMax));
                        from.SendMessage(String.Format("The skill gain difficulty has increased by {0}x of base",
                            PrestigeLevelConfig.LevelTwoDifficulty));
                        from.SendMessage("Base Luck 150");
                        break;
                    case 3:
                        from.SendMessage("You've reached Prestige Level 3!");
                        from.SendMessage(String.Format("Skill Cap: {0}", from.SkillsCap));
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
            else
            {
                from.SendMessage("You cannot use this.");
            }
        }

        private bool CanUse(int skillTotal, int prestigeLevel)
        {
            if (prestigeLevel == m_Level - 1)
            {
                switch (m_Level)
                {
                    case 1:
                        return skillTotal >= PrestigeLevelConfig.BaseSkillCap;
                    case 2:
                        return skillTotal >= PrestigeLevelConfig.LevelOneSkillCap;
                    case 3:
                        return skillTotal >= PrestigeLevelConfig.LevelTwoSkillCap;
                    default:
                        return false;
                }
            }

            return false;
        }
    }
}
