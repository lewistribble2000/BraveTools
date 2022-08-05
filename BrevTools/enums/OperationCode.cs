using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveClient.enums
{
    public enum OperationCode
    {
        NONE = -1,
        ALL = 0,

        Join = 2,
        Move = 22,
        TerritoryInformation = 114,
        LogoutStart = 122,
        GetCharacterStats = 139,
        SpecificMapData = 189,
        AllianceInfo = 209,
        GoldBuyOrderPrice = 237,
        GoldSellOrderPrice = 239,
        BuyGold = 241,
        SellGold = 242,
        GoldStats = 245,
        GoldHistory = 247,

        ClientHardwareStats = 299,
        ClientPerformanceStats = 300,
    }
}
