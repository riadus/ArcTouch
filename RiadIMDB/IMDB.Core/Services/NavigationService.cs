using IMDB.Core.ViewModels;
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

        public void ShowIncomingMovies()
        {
            ShowViewModel<IncomingMoviesViewModel>();
        }

        public void ShowMovieDetails(int? movieId)
        {
            if(movieId == null)
            {
                return;
            }
            ShowViewModel<MovieDetailViewModel>(new NavigatingObject { Id = movieId.Value });
        }

        public class NavigatingObject
        {
            public int Id { get; set; }
        }
    }
}
