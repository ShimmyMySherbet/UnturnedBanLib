using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnturnedBanLib.Models
{
    public class RegexFilter
    {
        public string RegexValue;
        public Regex Regex;
        public EBanFlags Flags;
    }
}
