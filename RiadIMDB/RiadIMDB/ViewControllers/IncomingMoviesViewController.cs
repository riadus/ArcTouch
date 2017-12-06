using System.Windows.Input;
using Foundation;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace RiadIMDB.iOS.ViewControllers
{
    public partial class IncomingMoviesViewController : MvxViewController<IncomingMoviesViewModel>
    {
        private SimpleTableViewSource _moviesTableViewSource;

        public IncomingMoviesViewController() : base("IncomingMoviesViewController", null)
        {
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<IncomingMoviesViewController, IncomingMoviesViewModel>();

            _moviesTableViewSource = new SimpleTableViewSource(MoviesTableView, MovieViewCell.Key, MovieViewCell.Key);

            bindingSet.Bind(_moviesTableViewSource)
                      .To(vm => vm.Movies);

            bindingSet.Bind(_moviesTableViewSource)
                      .For(s => s.WillEndCommand)
                      .To(vm => vm.LoadMoreCommand);

            bindingSet.Bind(_moviesTableViewSource)
                      .For(s => s.SelectedItem)
                      .To(vm => vm.SelectedMovie);
            
            MoviesTableView.Source = _moviesTableViewSource;
            bindingSet.Apply();
            MoviesTableView.RowHeight = 436;
            MoviesTableView.ReloadData();
            _moviesTableViewSource.SelectedItemChanged += _moviesTableViewSource_SelectedItemChanged;
        }

        void _moviesTableViewSource_SelectedItemChanged(object sender, System.EventArgs e)
        {
            if (_moviesTableViewSource.SelectedItem == null) { return; }
            _moviesTableViewSource.SelectedItem = null;
        }
    }

    public class SimpleTableViewSource : MvxSimpleTableViewSource
    {
        public SimpleTableViewSource(UITableView tableView, string nibName, string cellIdentifier = null, NSBundle bundle = null) : base(tableView, nibName, cellIdentifier, bundle)
        {
        }

        public ICommand WillEndCommand { get; set; }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if(indexPath.LongRow == ItemsSource.Count() - 1) {
                WillEndCommand?.Execute(null);
            }
            return base.GetCell(tableView, indexPath);
        }
    }
}

