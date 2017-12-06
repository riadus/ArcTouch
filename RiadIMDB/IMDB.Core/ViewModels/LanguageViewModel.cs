using IMDB.Data;
using MvvmCross.Core.ViewModels;

namespace IMDB.Core.ViewModels
{
    public class LanguageViewModel : MvxViewModel
    {
        public LanguageViewModel(Language language)
        {
            Language = language;
        }
        public Language Language { get; }

        private bool _isSelected;

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
