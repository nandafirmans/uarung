using System.Security.Cryptography;
using System.Text;

namespace Uarung.API.Utility
{
    public static class Crypt
    {
        public static string ToMD5(string text)
        {
            using (var md5 = MD5.Create())
            {
                return Exec(md5, text);
            }
        }

        public static string ToSHA256(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                return Exec(sha256, text);
            }
        }

        private static string Exec(HashAlgorithm hash, string text)
        {
            var bytesText = Encoding.Default.GetBytes(text);
            var hashBytes = hash.ComputeHash(bytesText);

            var sb = new StringBuilder();

            foreach (var t in hashBytes)
                sb.Append(t.ToString("X2"));

            return sb.ToString();
        }
    }
}