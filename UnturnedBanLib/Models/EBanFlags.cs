using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnturnedBanLib.Models
{
    public enum EBanFlags : uint
    {
        None = 0x0u,
        Hidden = 0x1u,
        MonetizationWarning = 0x2u,
        Blocked = 0x4u
    }
}
