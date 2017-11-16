using System;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;

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

            var source = new MvxSimpleTableViewSource(MoviesTableView, MovieViewCell.Key, MovieViewCell.Key);

            bindingSet.Bind(source)
                      .To(vm => vm.Movies);
            MoviesTableView.Source = source;

            bindingSet.Apply();
            MoviesTableView.RowHeight = 436;
            MoviesTableView.ReloadData();
        }
    }
}

