using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.Common;
using IMDB.Core.Services;
using IMDB.Data;
using IMDB.Domain.Interfaces;
using MvvmCross.Core.ViewModels;
using static IMDB.Core.Services.NavigationService;

namespace IMDB.Core.ViewModels
{
    public class IncomingMoviesViewModel : BaseViewModel
    {
        private readonly IBackendService _backendService;
        private readonly IDialogService _dialogService;
        private readonly IFileStorageService _fileStorageService;
        private readonly ILanguageService _languageService;
        private Language _currentLanguage;

        public IncomingMoviesViewModel(IBackendService backendService,
                                       IDialogService dialogService,
                                       IFileStorageService fileStorageService,
                                       ILanguageService languageService)
        {
            _backendService = backendService;
            _dialogService = dialogService;
            _fileStorageService = fileStorageService;
            _languageService = languageService;
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

        public MvxObservableCollection<MovieViewModel> Movies { get; set; }

        private async Task LoadMovies()
        {
            var movies = await _backendService.GetMovies(_currentLanguage).ConfigureAwait(false);
            Movies = movies.Select(movie => new MovieViewModel(movie, _fileStorageService, _languageService)).ToMvxObservableCollection();
            RaisePropertyChanged(nameof(Movies));
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
            AvailableLanguages = _movie.AvailableLanguages.Select(language => new LanguageViewModel(language)).ToList();
        }

        public string PosterPath => _fileStorageService.GetPath("Posters", _movie.PosterPath);
        public string Title => _movie.OriginalTitle;
        public Language OriginalLanguage { get; private set; }
        public string Overview => _movie.Overview;
        public string RelaseDate => _movie.ReleaseDate.ToString("D");
        public List<LanguageViewModel> AvailableLanguages { get; }
    }
}
