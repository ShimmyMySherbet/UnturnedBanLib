using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnturnedBanLib
{
    public static class extensions
    {
        public static byte ReadByted(this BinaryReader binary)
        {
            return (byte)binary.ReadByte();


        }
    }
}
