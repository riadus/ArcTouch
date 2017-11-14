using System;
using System.Threading.Tasks;
using IMDB.Domain.Interfaces;
using MvvmCross.Core.ViewModels;

namespace IMDB.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IBackendService _backendService;
        public HomeViewModel(IBackendService backendService)
        {
            _backendService = backendService;
            LoadCommand = new MvxAsyncCommand(LoadAsync);
        }

        public IMvxAsyncCommand LoadCommand { get; }

        private async Task LoadAsync()
        {
           var movies = await _backendService.GetMovies("");
        }
    }
}
