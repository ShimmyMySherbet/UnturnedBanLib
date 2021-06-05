using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using UnturnedBanLib.Models;

namespace UnturnedBanLib
{
    public class UnturnedBanClient
    {
        public const string Endpoint = "https://smartlydressedgames.com/UnturnedHostBans/filters.bin";
        private UTF8Encoding m_Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        public virtual UnturnedServerBans GetBans()
        {
            using (WebClient client = new WebClient())
            {
                return Parse(client.DownloadData(Endpoint));
            }
        }

        protected virtual UnturnedServerBans Parse(byte[] buffer)
        {
            List<IPv4Filter> ipFilters = new List<IPv4Filter>();
            List<RegexFilter> regexFilters = new List<RegexFilter>();
            using (MemoryStream mem = new MemoryStream(buffer))
            using (BinaryReader bin = new BinaryReader(mem))
            {
                if (mem.Length == 0 || bin.ReadByte() > 1)
                {
                    return new UnturnedServerBans() { IPv4Filters = ipFilters, RegexFilters = regexFilters };
                }

                var ipFilterCount = bin.ReadInt32();
                if (ipFilterCount > 0)
                {
                    for (int i = 0; i < ipFilterCount; i++)
                    {
                        IPv4Filter filter = new IPv4Filter();
                        filter.NumericIP = bin.ReadUInt32();
                        filter.IP = Utils.LongToIP(filter.NumericIP);
                        filter.minPort = bin.ReadUInt16();
                        filter.maxPort = bin.ReadUInt16();

                        var flagsValue = bin.ReadUInt32();
                        filter.Flags = (EBanFlags)flagsValue;
                        ipFilters.Add(filter);
                    }
                }

                int regexFilterCount = bin.ReadInt32();
                if (regexFilterCount > 0)
                {
                    for (int i = 0; i < regexFilterCount; i++)
                    {
                        RegexFilter filter = new RegexFilter();
                        var strlen = bin.ReadUInt16();
                        var regexBuffer = bin.ReadBytes(strlen);
                        var regexValue = m_Encoding.GetString(regexBuffer);
                        filter.RegexValue = regexValue;
                        filter.Regex = new Regex(regexValue);
                        filter.Flags = (EBanFlags)bin.ReadUInt32();
                        regexFilters.Add(filter);
                    }
                }
                return new UnturnedServerBans() { IPv4Filters = ipFilters, RegexFilters = regexFilters };
            }
        }
    }
}