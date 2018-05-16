// **********
// ServUO - ScrollOfPrestige.cs
// **********

namespace Server.Items
{
    public class ScrollOfPrestige : Item
    {
        private int m_Level;

        /// <summary>
        /// The level (1,2,3) of the scroll
        /// </summary>
        public int Level
        {
            get { return m_Level; }
        }

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

            writer.Write(Level);
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

            if (CanUse(from.SkillsTotal, from.PrestigeLevel))
            {
                from.PrestigeLevel = Level;
                Consume();
            }
            else
            {
                from.SendMessage("You cannot use this.");
            }
        }

        // TODO: come up with a sane way to share these limits from server.
        private bool CanUse(int skillTotal, int prestigeLevel)
        {
            switch (Level)
            {
                case 1:
                    return skillTotal == 7000 && prestigeLevel == 0;
                case 2:
                    return skillTotal == 14000 && prestigeLevel == 1;
                case 3:
                    return skillTotal == 21000 && prestigeLevel == 2;
                default:
                    return false;
            }
        }
    }
}
