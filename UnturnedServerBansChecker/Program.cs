using System;
using UnturnedBanLib;

namespace UnturnedServerBansChecker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new UnturnedBanClient();
            var bans = client.GetBans();

            foreach (var ipf in bans.IPv4Filters)
            {
                Console.WriteLine($"<IPv4 filter>");
                Console.WriteLine($"IP: {ipf.IP}");
                Console.WriteLine($"Port Range: {ipf.minPort} - {ipf.maxPort}");
                Console.WriteLine($"Flags: {ipf.Flags}");
                Console.WriteLine();
            }

            foreach (var reg in bans.RegexFilters)
            {
                Console.WriteLine($"<Regex Filter>");
                Console.WriteLine($"Pattern: {reg.RegexValue}");
                Console.WriteLine($"Flags: {reg.Flags}");
                Console.WriteLine();
            }

#if DEBUG
            Console.ReadLine();
#endif
        }
    }
}