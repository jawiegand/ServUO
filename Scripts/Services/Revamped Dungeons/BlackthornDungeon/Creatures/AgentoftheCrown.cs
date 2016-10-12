using Server;
using System;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Items;
using Server.ContextMenus;
using Server.Gumps;
using System.Collections;
using Server.Network;
using Server.Engines.Points;

namespace Server.Engines.Blackthorn
{
    public class AgentOfTheCrown : BaseCreature
    {
        public override bool IsInvulnerable { get { return true; } }

        [Constructable]
        public AgentOfTheCrown()
            : base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
        {
            Name = "Gus";
            Title = "the Agent Of The Crown";

            SetStr(110);
            SetDex(100);
            SetInt(1000);

            Hue = Utility.RandomSkinHue();
            Body = 0x190;
            HairItemID = 0x2047;
            HairHue = 0x46D;

            Item item = new ChainChest();
            item.Hue = 2106;
            AddItem(item);

            item = new ThighBoots();
            item.Hue = 2106;
            AddItem(item);

            item = new Obi();
            item.Hue = 1775;
            AddItem(item);

            item = new BodySash();
            item.Hue = 1775;
            AddItem(item);

            item = new GoldRing();
            AddItem(item);

            item = new Epaulette();
            AddItem(item);

            // QuiverOfInfinityBase

            item = new CloakBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new GargishClothWingArmorBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            // RoyalBritannianBase

            item = new DoubletBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new GargishSashBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new SurcoatBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new TunicBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            // RuneBeetleCarapaceBase

            item = new ChainmailTunicBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new DragonBreastplateBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new GargishPlatemailChestBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new GargishStoneChestBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new PlatemailTunicBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            item = new RingmailTunicBearingTheCrestOfBlackthorn();
            item.Movable = false;
            PackItem(item);

            // ShroudOfTheCondemnedBase

            item = new EpauletteBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new GargishEpauletteBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new GargishFancyBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new GargishRobeBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new GildedDressBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            // MysticsGarbBase

            item = new EpauletteBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new GargishEpauletteBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new GargishFancyBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new GargishRobeBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new GildedDressBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            // CloakOfSilenceBase

            item = new EpauletteBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new GargishEpauletteBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new GargishFancyBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new GargishRobeBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new GildedDressBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            // CloakOfPowerBase

            item = new EpauletteBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new GargishEpauletteBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new GargishFancyBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new GargishRobeBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new GildedDressBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn4();
            item.Movable = false;
            PackItem(item);

            // CloakOfLifeBase

            item = new EpauletteBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new GargishEpauletteBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new GargishFancyBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new GargishRobeBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new GildedDressBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn5();
            item.Movable = false;
            PackItem(item);

            // CloakOfDeathBase

            item = new EpauletteBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new GargishEpauletteBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new GargishFancyBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new GargishRobeBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new GildedDressBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn6();
            item.Movable = false;
            PackItem(item);

            // ConjurersGarbBase

            item = new EpauletteBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new GargishEpauletteBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new GargishFancyBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new GargishRobeBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new GildedDressBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn7();
            item.Movable = false;
            PackItem(item);

            // NightEyesBase

            item = new BandanaBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new BascinetBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new CircletBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new FeatheredHatBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new GargishEarringsBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new GargishGlassesBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new JesterHatBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new NorseHelmBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new PlateHelmBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new RoyalCircletBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new SkullcapBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new TricorneHatBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new WizardsHatBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            // MaceAndShieldBase

            item = new BandanaBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new BascinetBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new CircletBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new FeatheredHatBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new GargishEarringsBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new GargishGlassesBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new JesterHatBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new NorseHelmBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new PlateHelmBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new RoyalCircletBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new SkullcapBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new TricorneHatBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new WizardsHatBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            // FoldedSteelBase

            item = new BandanaBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new BascinetBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new CircletBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new FeatheredHatBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new GargishEarringsBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new GargishGlassesBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new JesterHatBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new NorseHelmBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new PlateHelmBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new RoyalCircletBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new SkullcapBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new TricorneHatBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            item = new WizardsHatBearingTheCrestOfBlackthorn3();
            item.Movable = false;
            PackItem(item);

            // TangleBase

            item = new GargishHalfApronBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new LeatherNinjaBeltBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new ObiBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            item = new WoodlandBeltBearingTheCrestOfBlackthorn1();
            item.Movable = false;
            PackItem(item);

            // CrimsonCinctureBase

            item = new GargishHalfApronBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new LeatherNinjaBeltBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new ObiBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);

            item = new WoodlandBeltBearingTheCrestOfBlackthorn2();
            item.Movable = false;
            PackItem(item);
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            if (from is PlayerMobile)
            {
                list.Add(new TurnInMinax(from, this));
                list.Add(new Claim(from, this));
            }                
        }

        private class TurnInMinax : ContextMenuEntry
        {
            private readonly Mobile m_Mobile;
            private readonly Mobile m_Vendor;
            private readonly ArrayList m_Buttons;
            public TurnInMinax(Mobile mobile, Mobile vendor)
                : base(1154571, 2)
            {
                this.m_Mobile = mobile;
                this.m_Vendor = vendor;

                m_Buttons = ToTTurnInGump.FindRedeemableItems(m_Mobile);

                if (m_Buttons.Count > 0)
                    this.Enabled = true;
                else
                    this.Enabled = false;
            }

            public override void OnClick()
            {
                m_Mobile.SendGump(new ToTTurnInGump(m_Vendor, m_Buttons));
            }
        }

        private class Claim : ContextMenuEntry
        {
            private readonly Mobile m_Mobile;
            private readonly Mobile m_Vendor;
            public Claim(Mobile mobile, Mobile vendor)
                : base(1154572, 2)
            {
                this.m_Mobile = mobile;
                this.m_Vendor = vendor;
            }

            public override void OnClick()
            {
                if (m_Mobile.CheckAlive())
                    m_Mobile.SendGump(new BlackthornRewardGump(m_Vendor, m_Mobile as PlayerMobile));
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile && from.InRange(this.Location, 5))
                from.SendGump(new BlackthornRewardGump(this, from as PlayerMobile));
        }

        public AgentOfTheCrown(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class ToTTurnInGump : BaseImageTileButtonsGump
    {
        public static ArrayList FindRedeemableItems(Mobile m)
        {
            Backpack pack = (Backpack)m.Backpack;
            if (pack == null)
                return new ArrayList();

            List<Item> items = pack.FindItemsByType<Item>();
            ArrayList buttons = new ArrayList();

            foreach (Item t in items)
            {
                if (t is BaseWeapon)
                {
                    BaseWeapon weapon = t as BaseWeapon;

                    if (weapon.ReforgedSuffix == ReforgedSuffix.Minax)
                        buttons.Add(new ItemTileButtonInfo(t));
                }
                else if (t is BaseArmor)
                {
                    BaseArmor armor = t as BaseArmor;

                    if (armor.ReforgedSuffix == ReforgedSuffix.Minax)
                        buttons.Add(new ItemTileButtonInfo(t));
                }
                else if (t is BaseJewel)
                {
                    BaseJewel jewel = t as BaseJewel;

                    if (jewel.ReforgedSuffix == ReforgedSuffix.Minax)
                        buttons.Add(new ItemTileButtonInfo(t));
                }
                else if (t is BaseClothing)
                {
                    BaseClothing cloth = t as BaseClothing;

                    if (cloth.ReforgedSuffix == ReforgedSuffix.Minax)
                        buttons.Add(new ItemTileButtonInfo(t));
                }
            }
            return buttons;
        }

        readonly Mobile m_Collector;

        public ToTTurnInGump(Mobile collector, ArrayList buttons)
            : base(1071012, buttons)// Click a minor artifact to give it to Ihara Soko.
        {
            this.m_Collector = collector;
        }

        public ToTTurnInGump(Mobile collector, ItemTileButtonInfo[] buttons)
            : base(1071012, buttons)// Click a minor artifact to give it to Ihara Soko.
        {
            this.m_Collector = collector;
        }

        public override void HandleButtonResponse(NetState sender, int adjustedButton, ImageTileButtonInfo buttonInfo)
        {
            PlayerMobile pm = sender.Mobile as PlayerMobile;

            Item item = ((ItemTileButtonInfo)buttonInfo).Item;

            if (!(pm != null && item.IsChildOf(pm.Backpack) && pm.InRange(this.m_Collector.Location, 7)))
                return;

            item.Delete();

            PointsSystem.Blackthorn.AwardPoints(pm, 1);

            pm.SendLocalizedMessage(1154518, "1"); // You have turned in ~1_COUNT~ artifacts bearing the crest of Minax.

            ArrayList buttons = FindRedeemableItems(pm);

            if (buttons.Count > 0)
                pm.SendGump(new ToTTurnInGump(this.m_Collector, buttons));
        }

        public override void HandleCancel(NetState sender)
        {
            PlayerMobile pm = sender.Mobile as PlayerMobile;

            if (pm == null || !pm.InRange(this.m_Collector.Location, 7))
                return;            
        }
    }

    public class Epaulette : BaseOuterTorso
    {
        public override int LabelNumber { get { return 1123325; } } // Epaulette

        [Constructable]
        public Epaulette()
            : base(0x9985)
        {
            this.Weight = 1.0;
        }

        public Epaulette(Serial serial)
            : base(serial)
        {
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