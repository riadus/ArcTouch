using System.Globalization;

namespace IMDB.Domain.Interfaces
{
    public interface IDeviceInformations
    {
        CultureInfo DeviceLanguage { get; }
    }
}
