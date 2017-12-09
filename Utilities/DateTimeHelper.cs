using System;
using System.Globalization;

namespace Utilities
{
    /// <summary>
    /// Set of function which help when dealing with datetimes
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Parses datetime input string
        /// </summary>
        /// <param name="dateString"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime ParseDateTime(string dateString, string format = "dd/MM/yyyy")
        {
            try
            {
                return DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        public const string DateFormatDatePicker = "yyyy-MM-dd";
        public const string DateFormatNet = "MM-dd-yyyy";
        public const string TimeFormatNet = "HH:mm:ss";

        /// <summary>
        /// Calculates the time interval for a given date
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static string TimeAgo(DateTime timestamp)
        {
            var t = Time(timestamp);
            return $"{t} ago";
        }


        /// <summary>
        /// Gives you an accurate calculation based on time
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static string Time(DateTime timestamp)
        {
            double difference = (DateTime.Now - timestamp).TotalSeconds;
            var periods = new string[8] { "second", "minute", "hour", "day", "week", "month", "years", "decade" };
            var lengths = new double[7] { 60, 60, 24, 7, 4.35, 12, 10 };
            int j = 0;
            for (j = 0; difference >= lengths[j]; j++)
            {
                difference /= lengths[j];
            }
            difference = Math.Round(difference);
            if (difference != 1) periods[j] += "s";

            return $"{difference} {periods[j]}";
        }
    }
}