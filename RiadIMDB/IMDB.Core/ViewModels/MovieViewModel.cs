using System;
using System.Linq;
using System.Threading.Tasks;
using IMDB.Core.Services;
using IMDB.Data;
using IMDB.Domain.Interfaces;
using static IMDB.Core.Services.NavigationService;

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

    public class MovieDetailViewModel : MovieViewModel
    {
        private readonly IBackendService _backendService;
        private readonly IDialogService _dialogService;
        public MovieDetailViewModel(IBackendService backendService, 
                                    IFileStorageService fileStorageService, 
                                    ILanguageService languageService, 
                                    INavigationService navigationService,
                                    IDialogService dialogService) : base(null, fileStorageService, languageService, navigationService)
        {
            _backendService = backendService;
            _dialogService = dialogService;
        }

        public async Task Init(NavigatingObject navigatingObject)
        {
            _dialogService.ShowMessage("Loading this special movie...", false, true);
            try
            {
                var movie = await _backendService.GetMovieDetail(navigatingObject.Id, LanguageService.CurrentLanguage).ConfigureAwait(false);
                Init(movie);
                RaiseAllPropertiesChanged();
                _dialogService.Hide();
            }
            catch (Exception)
            {
                _dialogService.Hide();
                _dialogService.ShowMessage("Er... The loading failed. May be the movie is not that worth it.", true, false);
            }
        }

        public string BackdropPath => _fileStorageService.GetPath("Backdrops", Movie?.BackdropPath ?? "");
    }
}
