using BraveClient.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveClient.network
{
    public abstract class PacketTemplate
    {
        public abstract PacketType Type { get;  }
        public abstract short Code { get; }
        public PacketTemplate(Dictionary<byte, object> rawData = null) { }
    }
}
