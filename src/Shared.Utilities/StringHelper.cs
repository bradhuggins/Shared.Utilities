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
        /// Serializes the object to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string SerializeObjectToString<T>(T obj)
        {
            Stream myStream = new MemoryStream();
            // Create a binary formatter and serialize the
            // myClass into the memorystream
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(myStream, obj);
            // Go to the beginning of the stream and
            // fill a byte array with the contents of the
            // memory stream
            myStream.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[myStream.Length];
            myStream.Read(buffer, 0, (int)myStream.Length);
            // Store the buffer as a base64 string in the cookie
            string output = Convert.ToBase64String(buffer);
            //close the stream
            myStream.Close();            
            return output;
        }

        /// <summary>
        /// Retrieves the object from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T RetrieveObjectFromString<T>(string value)
        {
            byte[] buffer = Convert.FromBase64String(value);
            Stream myStream = new MemoryStream(buffer);
            // Create a binary formatter and deserialize the
            // contents of the memory stream into MyClass
            IFormatter formatter = new BinaryFormatter();
            T result = (T)formatter.Deserialize(myStream);
            myStream.Close();
            return result;
        }

        public static string GenerateCleanGuid()
        {
            return Guid.NewGuid().ToString()
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace("-", string.Empty)
                .ToLower();
        }

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
