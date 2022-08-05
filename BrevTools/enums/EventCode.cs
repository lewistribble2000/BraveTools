using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveClient.enums
{
    public enum EventCode
    {
        NONE = -1,
        ALL = 0,

        //Updated codes
        PlayerInformation = 27,
        GuildChat = 65,
        GearEquip = 81,
    }
}
