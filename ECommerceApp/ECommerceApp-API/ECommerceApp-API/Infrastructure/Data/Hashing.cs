using System.Security.Cryptography;
using System.Text;

namespace ECommerceApp_API.Infrastructure.Data
{
    public class Hashing
    {
        public static string Hash(string source)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashByte.Length; i++)
                {
                    stringBuilder.Append(hashByte[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
