using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Mobiles.NPCs
{
    class PrestigeVendor : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

        [Constructable]
        public PrestigeVendor()
            : base("the prestige vendor")
        {
        }

        public PrestigeVendor(Serial serial)
            : base(serial)
        {
        }

        protected override List<SBInfo> SBInfos
        {
            get
            {
                return this.m_SBInfos;
            }
        }
        public override void InitSBInfo()
        {
            this.m_SBInfos.Add(new SBPrestigeVendor());
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
