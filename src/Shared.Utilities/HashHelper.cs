#region Using Statements
using System.Security.Cryptography;
using System.Text;
#endregion

namespace Shared.Utilities
{
    public class HashHelper
    {
        public static string ToSHA1(string input)
        {
            SHA1 sha1 = SHA1.Create();

            byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

            return StringHelper.ToHexString(hashBytes);
        }

        public static string ToMD5(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return StringHelper.ToHexString(hashBytes);
        }

    }
}
