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
        private const Language DefaultLanguage = Language.English;

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

        public Language? GetLanguage(string lang)
        {
            if (_languages.Any(x => x.ToString() == lang))
            {
                return _languages.FirstOrDefault(x => x.ToString() == lang);
            }
            return null;
        }

        private Language GetLanguage(CultureInfo cultureInfo)
        {
            if (cultureInfo != null)
            {
                var language = Normalize(cultureInfo.EnglishName);
                return GetLanguage(language) ?? DefaultLanguage;
            }
            return DefaultLanguage;
        }

        private string Normalize(string englishName)
        {
            return englishName.Split(' ')[0];
        }
    }
}
