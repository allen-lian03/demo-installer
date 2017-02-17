using System;
using System.Configuration;

namespace Demo.ClientLibs.Utils
{
    public class WCFAddress
    {
        private static string _baseAddress;

        public static string BaseAddress
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_baseAddress))
                {
                    _baseAddress = ConfigurationManager
                        .AppSettings["baseAddress"];
                    if (string.IsNullOrWhiteSpace(_baseAddress))
                    {
                        throw new ArgumentException("No found appSetting 'baseAddress'.");
                    }
                }
                return _baseAddress;
            }
        }
    }
}