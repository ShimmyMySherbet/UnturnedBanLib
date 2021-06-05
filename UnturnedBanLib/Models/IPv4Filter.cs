using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnturnedBanLib.Models
{
    public class IPv4Filter
    {
        public string IP;
        public uint NumericIP;

        public ushort minPort;

        public ushort maxPort;

        public EBanFlags Flags;

    }
}
