using System.Collections.Generic;
using System.Linq;
using IMDB.Data;
using IMDB.Domain.Attributes;
using IMDB.Domain.Interfaces;

namespace IMDB.Domain.Services
{
    [RegisterInterfaceAsDynamic]
    public class LanguageMapper : IMapper<Language, string>
    {
        private Dictionary<Language, string> _languageDictionary;


        public LanguageMapper()
        {
            _languageDictionary = new Dictionary<Language, string>{
                {Language.Arabic, "ar"},
                {Language.Bulgarian, "bg"},
                {Language.Czech, "cs"},
                {Language.Danish, "da"},
                {Language.Dutch, "nk"},
                {Language.English, "en"},
                {Language.Finnish, "fi"},
                {Language.French, "fr"},
                {Language.German, "de"},
                {Language.Greek, "el"},
                {Language.Hebrew, "he"},
                {Language.Hungarian, "hu"},
                {Language.Italian, "it"},
                {Language.Korean, "ko"},
                {Language.Mandarin, "zh"},
                {Language.Norwegian, "no"},
                {Language.Persian, "fa"},
                {Language.Polish, "pl"},
                {Language.Portuguese, "pt"},
                {Language.Russian, "ru"},
                {Language.Serbian, "sr"},
                {Language.Slovak, "sk"},
                {Language.Spanish, "es"},
                {Language.Turkish, "tr"},
                {Language.Ukrainian, "uk"},
                {Language.Other, ""}
            };
        }

        public string Map(Language source)
        {
            if (_languageDictionary.ContainsKey(source))
            {
                return _languageDictionary[source];
            }
            return _languageDictionary[Language.Other];
        }

        public Language MapBack(string source)
        {
            if(_languageDictionary.ContainsValue(source))
            {
                return _languageDictionary.First(x => x.Value == source).Key;
            }
            return Language.Other;
        }
    }
}