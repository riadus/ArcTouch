using System;
using System.Linq;
using System.Collections.Generic;
using IMDB.Data;
using IMDB.Domain.Interfaces;
using IMDB.Domain.Attributes;
using System.Globalization;

namespace IMDB.Domain.Services
{
    [RegisterInterfaceAsDynamic]
    public class LanguageService : ILanguageService
    {
        private readonly IDeviceInformations _deviceInformations;
        private const Language DefaultLanguage = Language.Arabic;

        private List<Language> _languages;

        public LanguageService(IDeviceInformations deviceInformations)
        {
            _deviceInformations = deviceInformations;
            SetLanguages();
        }

        private void SetLanguages()
        {
            var languages = Enum.GetValues(typeof(Language)) as Language[];
            _languages = languages?.ToList() ?? new List<Language>();
        }

        public IEnumerable<Language> Languages => _languages;

        public Language DeviceLanguage => GetLanguage(_deviceInformations.DeviceLanguage);

        private Language GetLanguage(CultureInfo cultureInfo)
        {
            var language = cultureInfo.EnglishName;
            if (_languages.Any(x => x.ToString() == language))
            {
                return _languages.FirstOrDefault(x => x.ToString() == language);
            }
            return DefaultLanguage;
        }
    }
}
