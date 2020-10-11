#region Using Statements
using System;
using System.Globalization;
#endregion

namespace Shared.Utilities
{
    public class DateTimeHelper
    {
        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static int ToInt(DateTime dateTime, string format = "yyyyMMdd")
        {
            return Int32.Parse(dateTime.ToString(format));
        }

        /// <summary>
        /// To the date.
        /// </summary>
        /// <param name="intDate">The int date.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static DateTime ToDate(int intDate, string format = "yyyyMMdd")
        {
            var outDate = DateTime.MinValue;
            DateTime.TryParseExact(intDate.ToString(), format, CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out outDate);

            return outDate;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public static string ToString(DateTime dateTime)
        {
            string result = string.Empty;
            if (dateTime > DateTime.MinValue && dateTime < DateTime.MaxValue)
            {
                result += dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
            }
            return result;
        }

        /// <summary>
        /// Gets the first day of month.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The DateTime Value of the first day of the specified month</returns>
        public static DateTime GetFirstDayOfMonth(DateTime value)
        {
            DateTime result = Convert.ToDateTime(value.Month.ToString() + "/1/" + value.Year.ToString());
            return result;
        }

        /// <summary>
        /// Gets the last day of month.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The DateTime Value of the last day of the specified month</returns>
        public static DateTime GetLastDayOfMonth(DateTime value)
        {
            return GetFirstDayOfMonth(value).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Gets the first day of quarter.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfQuarter(DateTime value)
        {
            DateTime toReturn = value;
            if (value >= Convert.ToDateTime("1/1/" + value.Year.ToString())
                        && toReturn <= Convert.ToDateTime("3/31/" + value.Year.ToString()))
            {
                toReturn = Convert.ToDateTime("1/1/" + value.Year.ToString());
            }
            else if (toReturn >= Convert.ToDateTime("4/1/" + value.Year.ToString())
                && toReturn <= Convert.ToDateTime("6/30/" + value.Year.ToString()))
            {
                toReturn = Convert.ToDateTime("4/1/" + value.Year.ToString());
            }
            else if (toReturn >= Convert.ToDateTime("7/1/" + value.Year.ToString())
                && toReturn <= Convert.ToDateTime("9/30/" + value.Year.ToString()))
            {
                toReturn = Convert.ToDateTime("7/1/" + value.Year.ToString());
            }
            else
            {
                toReturn = Convert.ToDateTime("10/1/" + value.Year.ToString());
            }
            return toReturn;
        }

        /// <summary>
        /// Gets the last day of quarter.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime GetLastDayOfQuarter(DateTime value)
        {
            return GetFirstDayOfQuarter(value).AddMonths(3).AddDays(-1);
        }

        #region Generate Date Time Filename Methods

        /// <summary>
        /// Generates the name of the date file.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string GenerateDateFileName(DateTime dt)
        {
            string result = dt.Year.ToString();
            result += dt.Month.ToString("0#");
            result += dt.Day.ToString("0#");            
            return result;
        }

        /// <summary>
        /// Generates the name of the date file.
        /// </summary>
        /// <param name="fileNamePrefix">The file name prefix.</param>
        /// <param name="fileNameSuffix">The file name suffix.</param>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string GenerateDateFileName(string fileNamePrefix, string fileNameSuffix, DateTime dt)
        {
            string result = string.Empty;
            if (fileNamePrefix != null)
            {
                result += fileNamePrefix;
            }
            result += GenerateDateFileName(dt);
            if (fileNameSuffix != null)
            {
                result += fileNameSuffix;
            }
            return result;
        }

        /// <summary>
        /// Generates the name of the date time file.
        /// </summary>
        /// <param name="dt">The DateTime</param>
        /// <returns>A string</returns>
        public static string GenerateDateTimeFileName(DateTime dt)
        {
            string result = dt.Year.ToString();
            result += dt.Month.ToString("0#");
            result += dt.Day.ToString("0#");
            result += @"_";
            result += dt.Hour.ToString("0#");
            result += dt.Minute.ToString("0#");
            return result;
        }

        /// <summary>
        /// Generates the name of the date time file.
        /// </summary>
        /// <param name="fileNamePrefix">The file name prefix.</param>
        /// <param name="fileNameSuffix">The file name suffix.</param>
        /// <param name="dt">The DateTime</param>
        /// <returns>A string</returns>
        public static string GenerateDateTimeFileName(string fileNamePrefix, string fileNameSuffix, DateTime dt)
        {
            string result = string.Empty;
            if (fileNamePrefix != null)
            {
                result += fileNamePrefix;
            }
            result += GenerateDateTimeFileName(dt);
            if (fileNameSuffix != null)
            {
                result += fileNameSuffix;
            }
            return result;
        }

        #endregion


    }

}
