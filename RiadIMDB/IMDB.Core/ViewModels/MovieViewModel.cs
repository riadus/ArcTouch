using System.Linq;
using IMDB.Core.Services;
using IMDB.Data;
using IMDB.Domain.Interfaces;

namespace IMDB.Core.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        protected Movie Movie { get; set; }
        protected readonly IFileStorageService _fileStorageService;
        protected readonly ILanguageService _languageService;

        public MovieViewModel(Movie movie,
                              IFileStorageService fileStorageService,
                              ILanguageService languageService,
                              INavigationService navigationService) : base(languageService, navigationService)
        {
            _fileStorageService = fileStorageService;
            _languageService = languageService;
            if(movie != null)
            {
                Init(movie);
            }
        }

        protected void Init(Movie movie)
        {
            Movie = movie;
            Genres = Movie?.Genres?.Where(genre => !string.IsNullOrEmpty(genre))?.Aggregate(HandleFunc);
            OriginalLanguage = Movie.OriginalLanguage;
            UserLanguage =  _languageService.CurrentLanguage;
        }

        public int? Id => Movie?.Id;
        public string PosterPath => _fileStorageService.GetPath("Posters", Movie.PosterPath);
        public string Title => Movie?.OriginalTitle;
        public Language OriginalLanguage { get; private set; }
        public string Overview => Movie?.Overview;
        public string RelaseDate => Movie?.ReleaseDate.ToString("D");
        public string Genres { get; private set; }
        public bool UserLanguageIsAvailable => Movie?.AvailableLanguages != null && Movie.AvailableLanguages.Any(language => language == _languageService.CurrentLanguage) && _languageService.CurrentLanguage != OriginalLanguage;
        public Language UserLanguage { get; private set; }
        string HandleFunc(string arg1, string arg2)
        {
            return $"{arg1}, {arg2}";
        }
    }
}
