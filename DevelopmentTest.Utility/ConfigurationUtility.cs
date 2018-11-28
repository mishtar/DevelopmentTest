using System;
using System.Configuration;

namespace DevelopmentTest.Utility
{
    public static class ConfigurationUtility
    {
        public static T GetConfigValue<T>(string key) where T : class
        {
            var value = ConfigurationManager.AppSettings[key];

            return Convert.ChangeType(value, typeof(T)) as T;
        }
    }
}
