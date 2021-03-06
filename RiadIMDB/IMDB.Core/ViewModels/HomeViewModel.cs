﻿using System.Linq;
using Cheesebaron.MvxPlugins.Connectivity;
using IMDB.Common;
using IMDB.Core.Services;
using IMDB.Data;
using IMDB.Domain.Interfaces;
using MvvmCross.Core.ViewModels;

namespace IMDB.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ILanguageService _languageService;
        private readonly IDialogService _dialogService;
        private readonly IConnectivity _connectivity;


        public HomeViewModel(INavigationService navigationService,
                             ILanguageService languageService,
                             IDialogService dialogService, 
                             IConnectivity connectivity) : base(languageService, navigationService)
        {
            _navigationService = navigationService;
            _languageService = languageService;
            _dialogService = dialogService;
            _connectivity = connectivity;
            NavigateToIncomingMoviesCommand = new MvxCommand(NavigateToIncomingMovies);
            Init();
        }

        public override void ViewAppeared()
        {
            RaisePropertyChanged(nameof(SelectedLanguageIndex));
            base.ViewAppeared();
        }

        public void Init()
        {
            SupportedLanguages = _languageService.Languages.Where(x => x != Language.Other).Select(x => new LanguageViewModel(x)).ToMvxObservableCollection();
            SelectedLanguage = SupportedLanguages.FirstOrDefault(x => x.Language == _languageService.DeviceLanguage);
        }

        public string NavigateButtonTxt => "See incoming movies";

        public IMvxCommand NavigateToIncomingMoviesCommand { get; }
        private void NavigateToIncomingMovies()
        {
           
            if (_connectivity.IsConnected)
            {
                _languageService.CurrentLanguage = SelectedLanguage.Language;
                _navigationService.ShowIncomingMovies();
            }
            else
            {
                _dialogService.ShowMessage("90% of the time, we need the Internet in our life. This app is part of those 90%. Please feed us in some 01010101", true, false);
            }
        }

        public MvxObservableCollection<LanguageViewModel> SupportedLanguages { get; private set; }
        private LanguageViewModel _selectedLanguage;

        public LanguageViewModel SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }

            set
            {
                if(_selectedLanguage == value)
                {
                    return;
                }
                if(_selectedLanguage != null)
                {
                    _selectedLanguage.IsSelected = false;
                }
                _selectedLanguage = value;
                _selectedLanguage.IsSelected = true;
                RaisePropertyChanged(nameof(SelectedLanguageIndex));
                RaisePropertyChanged();
            }
        }

        public int SelectedLanguageIndex => SupportedLanguages.IndexOf(SelectedLanguage);
    }
}
