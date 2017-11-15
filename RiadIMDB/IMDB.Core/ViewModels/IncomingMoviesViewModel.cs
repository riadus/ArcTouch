using System;
using System.Threading.Tasks;
using IMDB.Core.Services;
using IMDB.Data;
using IMDB.Domain.Interfaces;
using static IMDB.Core.Services.NavigationService;

namespace IMDB.Core.ViewModels
{
    public class IncomingMoviesViewModel : BaseViewModel
    {
        private readonly IBackendService _backendService;
        private readonly IDialogService _dialogService;
        private Language _currentLanguage;

        public IncomingMoviesViewModel(IBackendService backendService,
                                      IDialogService dialogService)
        {
            _backendService = backendService;
            _dialogService = dialogService;
        }

        public async Task Init(NavigationObject navigationObject)
        {
            try
            {
                _dialogService.ShowMessage("Loading those great movies", false);
                _currentLanguage = navigationObject.Language;
                await LoadMovies().ConfigureAwait(false);
                _dialogService.Hide();
            }
            catch (Exception)
            {
                _dialogService.Hide();
                _dialogService.ShowMessage("Oops, how embarassing for the developer. An error occured and they did not handle it.", true);
            }
        }

        private async Task LoadMovies()
        {
            var movies = await _backendService.GetMovies(_currentLanguage).ConfigureAwait(false);
            var count = movies;
        }
    }

    public class MovieViewModel : BaseViewModel
    {
        private readonly Movie _movie;
        private readonly IFileStorageService _fileStorageService;
        private readonly ILanguageService _languageService;
        public MovieViewModel(Movie movie, 
                              IFileStorageService fileStorageService,
                              ILanguageService languageService)
        {
            _movie = movie;
            _fileStorageService = fileStorageService;
            _languageService = languageService;
            OriginalLanguage = _languageService.GetLanguage(_movie.OriginalLanguage) ?? Language.Other;
        }

        public string PosterPath => _fileStorageService.GetPath("Posters", _movie.PosterPath);
        public string Title => _movie.OriginalTitle;
        public Language OriginalLanguage { get; private set; }
        public string Overview => _movie.Overview;
        public string RelaseDate => _movie.ReleaseDate.ToString("D");
    }
}
