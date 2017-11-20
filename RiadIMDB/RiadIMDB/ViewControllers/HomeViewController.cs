using CoreGraphics;
using Foundation;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;

namespace RiadIMDB.iOS.ViewControllers
{
    public partial class HomeViewController : MvxViewController<HomeViewModel>
    {
        public HomeViewController() : base("HomeViewController", null)
        {
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<HomeViewController, HomeViewModel>();
            bindingSet.Bind(NavigateToUpcompingMoviesBtn)
                      .To(vm => vm.NavigateToIncomingMoviesCommand);

            var source = new MvxSimpleTableViewSource(LanguagesTableView, LanguageViewCell.Key, LanguageViewCell.Key);

            bindingSet.Bind(source)
                      .To(vm => vm.SupportedLanguages);
            bindingSet.Bind(source)
                      .For(table => table.SelectedItem)
                      .To(vm => vm.SelectedLanguage);
            LanguagesTableView.Source = source;

            bindingSet.Apply();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;

            LanguagesTableView.ReloadData();
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.SelectedLanguageIndex))
            {
                CenterSelectedLanguage();
            }
        }

        private void CenterSelectedLanguage()
        {
            LanguagesTableView.ScrollToRow(NSIndexPath.FromRowSection(ViewModel.SelectedLanguageIndex, 0),
                                           UIKit.UITableViewScrollPosition.Middle, true);
        }

        public override void ViewDidAppear(bool animated)
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
                ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            }
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            base.ViewWillDisappear(animated);
        }

        override observe
    }
}

