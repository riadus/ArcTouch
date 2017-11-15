using System.Globalization;
using Foundation;
using IMDB.Domain.Interfaces;

namespace RiadIMDB.iOS.IoC
{
    public class DeviceInformationsIOS : IDeviceInformations
    {
        public DeviceInformationsIOS()
        {
            DeviceLanguage = new CultureInfo(NSBundle.MainBundle.PreferredLocalizations[0]);
        }

        public CultureInfo DeviceLanguage { get; }
    }
}
