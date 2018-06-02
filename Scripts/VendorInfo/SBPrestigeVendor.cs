using Server.Items;
using System.Collections.Generic;

/// <summary>
/// Definition of the vendor inventory for prestige vendor
/// </summary>
namespace Server.Mobiles
{
    public class SBPrestigeVendor : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new List<GenericBuyInfo>()
        {
                new GenericBuyInfo(typeof(PrestigeScroll), 1500000, 20, 0x14F0, 1161, new object[] { 1 }), // SoP level 1
                new GenericBuyInfo(typeof(PrestigeScroll), 3000000, 10, 0x14F0, 1161, new object[] { 2 })  // SoP level 2
        };
        private readonly IShopSellInfo m_SellInfo = new GenericSellInfo();

        public SBPrestigeVendor()
        {
        }

        /// <summary>
        /// Returns a list of items that this vendor sells
        /// </summary>
        public override IShopSellInfo SellInfo
        {
            get
            {
                return m_SellInfo;
            }
        }

        /// <summary>
        /// Returns a list of items that this vendor buys
        /// </summary>
        public override List<GenericBuyInfo> BuyInfo
        {
            get
            {
                return m_BuyInfo;
            }
        }
    }
}
