using IMDB.Data;

namespace IMDB.Core.Services
{
    public interface INavigationService
    {
        void ShowHomePage();
        void ShowIncomingMovies(Language language);
    }
}
