using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.Utilities.Seguridad
{
    public class SeguridadContrasena
    {
        /// <summary>
        /// Encrypt Password
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string Encrypt(string Password)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(Password);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// <summary>
        /// Decrypt Password
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string Decrypt(string Password)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(Password);
            Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
