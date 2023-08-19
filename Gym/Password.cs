using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Gym
{
    class Password
    {
        // encode password to 64 Base hash code         
        public static string Hash(string password)
        {
            return Convert.ToBase64String(
                HashAlgorithm.Create("SHA1").ComputeHash(Encoding.Unicode.GetBytes(password))
            );
        }
    }
}
