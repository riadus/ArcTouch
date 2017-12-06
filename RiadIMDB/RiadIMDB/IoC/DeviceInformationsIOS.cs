using System;
using System.Globalization;
using Foundation;
using IMDB.Domain.Interfaces;

namespace RiadIMDB.iOS.IoC
{
    public class DeviceInformationsIOS : IDeviceInformations
    {
        public DeviceInformationsIOS()
        {
            DeviceLanguage = TryLanguageParse(NSLocale.PreferredLanguages[0]);
        }

        private CultureInfo TryLanguageParse(string language)
        {
            try
            {
                return new CultureInfo(language);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public CultureInfo DeviceLanguage { get; }
    }
}
