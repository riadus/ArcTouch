using IMDB.Core.ViewModels;
using IMDB.Data;
using IMDB.Domain.Attributes;
using MvvmCross.Core.ViewModels;

namespace IMDB.Core.Services
{
    [RegisterInterfaceAsDynamic]
    public class NavigationService : MvxNavigatingObject, INavigationService
    {
        public void ShowHomePage()
        {
            ShowViewModel<HomeViewModel>();
        }

        public void ShowIncomingMovies(Language language)
        {
            ShowViewModel<IncomingMoviesViewModel>(new NavigationObject{
                Language = language
            });
        }

        public class NavigationObject{
            public Language Language { get; set; }
        }
    }
}
