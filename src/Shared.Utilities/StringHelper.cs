#region Using Statements
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
#endregion

namespace Shared.Utilities
{
    public class StringHelper
    {

        /// <summary>
        /// Used to convert a string into the Base64 encoded representation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToBase64EncodedString(string value)
        {
            string result = Convert.ToBase64String(Encoding.Default.GetBytes(value.Trim()));
            return result;
        }

        /// <summary>
        /// Used to decode a Based64 encoded string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToBase64DecodedString(string value)
        {
            string result = Encoding.Default.GetString(Convert.FromBase64String(value.Trim()));
            return result;
        }

        /// <summary>
        /// Reverses the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string Reverse(string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }

        /// <summary>
        /// Strips the non numeric characters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string StripNonNumericCharacters(string value)
        {
            string result = string.Empty;
            char[] characters = value.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(characters[i].ToString(), @"^[0-9]"))
                {
                    result += characters[i].ToString();
                }
            }
            return result;
        }

        /// <summary>
        /// Generates the clean unique identifier.
        /// </summary>
        /// <returns></returns>
        public static string GenerateCleanGuid()
        {
            return Guid.NewGuid().ToString()
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace("-", string.Empty)
                .ToLower();
        }

        /// <summary>
        /// Converts to hexstring.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

    }
}
