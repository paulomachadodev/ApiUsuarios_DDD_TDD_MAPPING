using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Helpers
{
    public static class MD5Helper
    {
        public static string Encrypt(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();

                foreach (var item in data)
                    sBuilder.Append(item.ToString("x2"));

                return sBuilder.ToString();
            }
        }
    }
}



