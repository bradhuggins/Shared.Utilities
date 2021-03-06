﻿#region Using Statements
using System.Security.Cryptography;
using System.Text;
#endregion

namespace Shared.Utilities
{
    /// <summary>
    /// Hash helper class
    /// </summary>
    public class HashHelper
    {
        /// <summary>
        /// Converts to sha1.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ToSHA1(string input)
        {
            SHA1 sha1 = SHA1.Create();

            byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

            return StringHelper.ToHexString(hashBytes);
        }

        /// <summary>
        /// Converts to md5.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ToMD5(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return StringHelper.ToHexString(hashBytes);
        }

    }
}
