using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace data.resource.Authentication
{
    public static class Token
    {
        private static byte[] Key { get; set; } = Encoding.UTF8.GetBytes("asfjgasmokgna123asfkngaknakmg");
        
        public static void CreateKey()
        {
            if(Key == null)
            {
                //Key = RandomNumberGenerator.GetBytes(32);
            }
        }

        public static byte[] GetKey()
        {
            return Key;
        }
    }
}
