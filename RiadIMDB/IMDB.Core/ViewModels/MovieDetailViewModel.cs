using System;
using System.Threading.Tasks;
using IMDB.Core.Services;
using IMDB.Domain.Interfaces;
using static IMDB.Core.Services.NavigationService;

namespace IMDB.Core.ViewModels
{
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
