using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.BLL
{
    public static class UrlShortener
    {
        private static readonly string[] allowedCharacters = {
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
        "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
        "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
    };

        public static string ShortenUrl(string url)
        {
            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(url));

            var sb = new StringBuilder();
            for (var i = 0; i < 6; i++)
            {
                var index = hash[i] % allowedCharacters.Length;
                sb.Append(allowedCharacters[index]);
            }

            return sb.ToString();
        }

    }
}
