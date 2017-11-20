using System;
using System.Linq;
using System.Threading.Tasks;
using IMDB.Common;
using IMDB.Core.Services;
using IMDB.Data;
using IMDB.Domain.Interfaces;
using MvvmCross.Core.ViewModels;

namespace IMDB.Core.ViewModels
{
    public class IncomingMoviesViewModel : BaseViewModel
    {
        private readonly IBackendService _backendService;
        private readonly IDialogService _dialogService;
        private readonly IFileStorageService _fileStorageService;
        private Language _currentLanguage;

        public IncomingMoviesViewModel(IBackendService backendService,
                                       IDialogService dialogService,
                                       IFileStorageService fileStorageService,
                                       ILanguageService languageService,
                                       INavigationService navigationService) : base(languageService, navigationService)
        {
            _backendService = backendService;
            _dialogService = dialogService;
            _fileStorageService = fileStorageService;
            LoadMoreCommand = new MvxAsyncCommand(LoadMore);
        }

        public async Task Init()
        {
            try
            {
                _dialogService.ShowMessage("Loading those great movies", false, true);
                _currentLanguage = LanguageService.CurrentLanguage;
                await LoadMovies().ConfigureAwait(false);
                _dialogService.Hide();
            }
            catch (Exception)
            {
                _dialogService.Hide();
                _dialogService.ShowMessage("Oops, how embarassing for the developer. An error occured and they did not handle it.", true, false);
            }
        }

        public MvxObservableCollection<MovieViewModel> Movies { get; set; }

        private async Task LoadMovies()
        {
            var movies = await _backendService.GetMovies(_currentLanguage).ConfigureAwait(false);
            Movies = movies.Select(movie => new MovieViewModel(movie, _fileStorageService, LanguageService, NavigationService)).ToMvxObservableCollection();
            RaisePropertyChanged(nameof(Movies));
        }

        private MovieViewModel _selectedMovie;

        public MovieViewModel SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }

            set
            {
                if (value != null)
                {
                    _selectedMovie = value;
                    NavigationService.ShowMovieDetails(_selectedMovie.Id);
                }
            }
        }

        public IMvxAsyncCommand LoadMoreCommand { get; }

        private async Task LoadMore()
        {
            try
            {
                _dialogService.ShowMessage("Loading even more great movies", true, true);
                var movies = await _backendService.GetMoreMovies(LanguageService.CurrentLanguage).ConfigureAwait(false);
                if (!movies.Any())
                {
                    return;
                }
                Movies.AddRange(movies.Select(movie => new MovieViewModel(movie, _fileStorageService, LanguageService, NavigationService)));
                _dialogService.Hide();
            }
            catch (Exception)
            {
                _dialogService.Hide();
                _dialogService.ShowMessage("Oops, how embarassing for the developer. An error occured and they did not handle it.", true, false);
            }
        }
    }
}
