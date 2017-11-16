using System;

using Foundation;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace RiadIMDB.iOS.ViewControllers
{
    public partial class MovieViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MovieViewCell");
        public static readonly UINib Nib;
        private MvxImageViewLoader _imageViewLoader;

        static MovieViewCell()
        {
            Nib = UINib.FromName("MovieViewCell", NSBundle.MainBundle);
        }

        protected MovieViewCell(IntPtr handle) : base(handle)
        {
            _imageViewLoader = new MvxImageViewLoader(() => PosterImage);
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<MovieViewCell, MovieViewModel>();
            bindingSet.Bind(PosterImage);
            bindingSet.Bind(_imageViewLoader)
                      .For(i => i.ImageUrl).
                      To(vm => vm.PosterPath);
            bindingSet.Bind(TitleLabel)
                      .To(vm => vm.Title);
            bindingSet.Bind(OverviewLabel)
                      .To(vm => vm.Overview);

            bindingSet.Apply();
            TitleLabel.SizeToFit();
        }
    }
}
