using System;
using System.Windows.Input;
using Foundation;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace RiadIMDB.iOS.ViewControllers
{
    public partial class IncomingMoviesViewController : MvxViewController<IncomingMoviesViewModel>
    {
        public IncomingMoviesViewController() : base("IncomingMoviesViewController", null)
        {
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<IncomingMoviesViewController, IncomingMoviesViewModel>();

            var source = new SimpleTableViewSource(MoviesTableView, MovieViewCell.Key, MovieViewCell.Key);

            bindingSet.Bind(source)
                      .To(vm => vm.Movies);

            bindingSet.Bind(source)
                      .For(s => s.WillEndCommand)
                      .To(vm => vm.LoadMoreCommand);
            
            MoviesTableView.Source = source;

            bindingSet.Bind(source)
                      .For(s => s.SelectedItem)
                      .To(vm => vm.SelectedMovie);

            bindingSet.Apply();
            MoviesTableView.RowHeight = 436;
            MoviesTableView.ReloadData();
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

