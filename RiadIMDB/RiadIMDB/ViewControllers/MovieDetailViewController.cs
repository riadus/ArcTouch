using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;

namespace RiadIMDB.iOS.Views
{
    public partial class MovieDetailViewController : MvxViewController<MovieDetailViewModel>
    {
        private readonly MvxImageViewLoader _backdropImageViewLoader;
        public MovieDetailViewController() : base("MovieDetailViewController", null)
        {
            _backdropImageViewLoader = new MvxImageViewLoader(() => BackdropImage);
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<MovieDetailViewController, MovieDetailViewModel>();
            bindingSet.Bind(_backdropImageViewLoader)
                      .To(vm => vm.BackdropPath);
            bindingSet.Bind(TitleLabel)
                      .To(vm => vm.Title);
            bindingSet.Bind(ReleaseDateLabel)
                      .To(vm => vm.RelaseDate);
            bindingSet.Bind(GenresLabel)
                      .To(vm => vm.Genres);
            bindingSet.Bind(OverviewLabel)
                      .To(vm => vm.Overview);
            bindingSet.Apply();
            OverviewWidthConstraint.Constant = View.Frame.Width - 60;
        }
    }
}

