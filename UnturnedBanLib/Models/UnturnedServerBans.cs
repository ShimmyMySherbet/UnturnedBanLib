using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnturnedBanLib.Models
{
    public class UnturnedServerBans
    {
        public List<IPv4Filter> IPv4Filters = new List<IPv4Filter>();
        public List<RegexFilter> RegexFilters = new List<RegexFilter>();
    }
}
