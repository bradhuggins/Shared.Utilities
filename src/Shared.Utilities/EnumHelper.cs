#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
#endregion

namespace Shared.Utilities
{
    //// http://msdn.microsoft.com/en-us/library/aa347875.aspx

    public class EnumHelper
    {
        /// <summary>
        /// Gets the description from enum value. (because Description Attribute is not serializable.)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string</returns>
        public static string GetDescriptionFromEnumValue(Enum value)
        {
            string toReturn = string.Empty;
            EnumMemberAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;
            toReturn = attribute == null ? value.ToString() : attribute.Value;

            if (toReturn == null)
            {
                toReturn = System.Enum.GetName(value.GetType(), value);
            }
            return toReturn;
        }

        ///// <summary>
        ///// Gets the values.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns>IEnumerable T</returns>
        //public static IEnumerable<T> GetValues<T>()
        //{
        //    return Enum.GetValues(typeof(T)).Cast<T>();
        //}
    }
}
