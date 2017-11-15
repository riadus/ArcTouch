using IMDB.Data;

namespace IMDB.Core.ViewModels
{
    public class LanguageViewModel : BaseViewModel
    {
        public LanguageViewModel(Language language)
        {
            Language = language;
        }
        public string Path => $"{Language}.png";
        public Language Language { get; }

        bool _isSelected;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        public override bool Equals(object obj)
        {
            var languageViewModel = obj as LanguageViewModel;
            if(languageViewModel == null){
                return false;
            }

            return languageViewModel.Language == Language;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
