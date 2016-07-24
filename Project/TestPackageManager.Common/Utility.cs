using System;
using System.Configuration;
using System.Diagnostics;

namespace TestPackageManager.Common
{
    public class Utility
    {
        /// <summary>
        /// Get Application Settings by config key
        /// </summary>
        /// <param name="key">string key</param>
        /// <returns>Returns parsed value</returns>
        public static T GetAppSetting<T>(string key, T defaultValue)
        {
            //Testing changes
            if (string.IsNullOrEmpty(key))
            {
                throw (new ArgumentNullException("Application Setting key is null or empty"));
            }

            if (ConfigurationManager.AppSettings[key] == null)
            {
                return defaultValue;

            }

            string settingValue = ConfigurationManager.AppSettings[key];

            return TryParse<T>(settingValue);
        }

        private static T TryParse<T>(string settingValue)
        {
            try
            {

                if (settingValue == null)
                {
                    return default(T);
                }

                return (T)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(settingValue));

            }
            catch (Exception ex)
            {
                Debug.Print("Exception: {0}", ex.Message);

                throw new Exception("Error trying to parse setting - " + settingValue.ToString());

            }

        }
    }
}
