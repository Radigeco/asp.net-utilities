using System;
using System.Configuration;

namespace Utilities
{
    /// <summary>
    /// Set of function which help deal with ASP.Net Configuration manager
    /// </summary>
    public static class ConfigurationManagerHelper
    {
        /// <summary>
        /// Returns the appsetting as string based on given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingsByKey(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key];
                return value;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Returns the app setting as int based on given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetAppSettingsByKeyAsInt(string key)
        {
            return Convert.ToInt32(GetAppSettingsByKey(key));
        }

        /// <summary>
        /// Returns the app setting as double based given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static double GetAppSettingsByKeyAsDouble(string key)
        {
            return Convert.ToDouble(GetAppSettingsByKey(key));
        }

        /// <summary>
        /// Returns the app setting as decimal based on given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetAppSettingsByKeyAsDecimal(string key)
        {
            return Convert.ToDecimal(GetAppSettingsByKey(key));
        }
    }
}