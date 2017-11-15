using System.Collections.Generic;
using IMDB.Data;

namespace IMDB.Domain.Interfaces
{
    public interface ILanguageService
    {
        IEnumerable<Language> Languages { get; }
        Language DeviceLanguage { get; }
        Language? GetLanguage(string lang);
    }
}
