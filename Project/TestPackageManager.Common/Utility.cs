using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPackageManager.Common
{
    public class Utility
    {
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
