using IMDB.Data;
using IMDB.Domain.Attributes;
using IMDB.Domain.Interfaces;

namespace IMDB.Domain.Services
{
    [RegisterInterfaceAsDynamic]
    public class LanguageMapper : IMapper<Language, string>
    {
        public string Map(Language source)
        {
            switch (source)
            {
                case Language.Arabic:
                    return "ar";
                case Language.Bulgarian:
                    return "bg";
                case Language.Czech:
                    return "cs";
                case Language.Danish:
                    return "da";
                case Language.Dutch:
                    return "nl";
                case Language.English:
                    return "en";
                case Language.Finnish:
                    return "fi";
                case Language.French:
                    return "fr";
                case Language.German:
                    return "de";
                case Language.Greek:
                    return "el";
                case Language.Hebrew:
                    return "he";
                case Language.Hungarian:
                    return "hu";
                case Language.Italian:
                    return "it";
                case Language.Korean:
                    return "ko";
                case Language.Mandarin:
                    return "zh";
                case Language.Norwegian:
                    return "no";
                case Language.Persian:
                    return "fa";
                case Language.Polish:
                    return "pl";
                case Language.Portuguese:
                    return "pt";
                case Language.Russian:
                    return "ru";
                case Language.Serbian:
                    return "sr";
                case Language.Slovak:
                    return "sk";
                case Language.Spanish:
                    return "es";
                case Language.Turkish:
                    return "tr";
                case Language.Ukrainian:
                    return "uk";
                default:
                    return "en";
            }
        }
    }
}
