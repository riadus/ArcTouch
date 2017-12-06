using IMDB.Core.Services;
using IMDB.Domain.Interfaces;
using MvvmCross.Core.ViewModels;

namespace IMDB.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected ILanguageService LanguageService { get; }
        protected INavigationService NavigationService { get; }

        protected BaseViewModel(ILanguageService languageService,
                                INavigationService navigationService)
        {
            LanguageService = languageService;
            NavigationService = navigationService;
        }
    }
}
