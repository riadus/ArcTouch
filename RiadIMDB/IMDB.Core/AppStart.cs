using System;
using IMDB.Core.Services;
using MvvmCross.Core.ViewModels;

namespace IMDB.Core
{
    public class AppStart : IMvxAppStart
    {
        private INavigationService NavigationService { get; }
        public AppStart(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void Start(object hint = null)
        {
            NavigationService.ShowHomePage();
        }
    }
}
