using System;

using Foundation;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using RiadIMDB.iOS.Converters;
using RiadIMDB.iOS.Views;
using UIKit;

namespace RiadIMDB.iOS.ViewControllers
{
    public partial class MovieViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MovieViewCell");
        public static readonly UINib Nib;
        private MvxImageViewLoader _posterImageViewLoader;
        private MvxImageViewLoader _originalLanguageImageViewLoader;
        private MvxImageViewLoader _userLanguageImageViewLoader;

        static MovieViewCell()
        {
            Nib = UINib.FromName("MovieViewCell", NSBundle.MainBundle);
        }

        protected MovieViewCell(IntPtr handle) : base(handle)
        {
            _posterImageViewLoader = new MvxImageViewLoader(() => PosterImage);
            _originalLanguageImageViewLoader = new MvxImageViewLoader(() => OriginalLanguageImage);
            _userLanguageImageViewLoader = new MvxImageViewLoader(() => UserLanguageImage);
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<MovieViewCell, MovieViewModel>();
            bindingSet.Bind(_originalLanguageImageViewLoader)
                      .For(i => i.ImageUrl)
                      .To(vm => vm.OriginalLanguage)
                      .WithConversion(new ImagePathConverter());
            bindingSet.Bind(_userLanguageImageViewLoader)
                      .For(i => i.ImageUrl)
                      .To(vm => vm.UserLanguage)
                      .WithConversion(new ImagePathConverter());
            bindingSet.Bind(UserLanguageImage)
                      .For(i => i.Hidden)
                      .To(vm => vm.UserLanguageIsAvailable)
                      .WithConversion(new ReverseBooleanConverter());
            bindingSet.Bind(_posterImageViewLoader)
                      .For(i => i.ImageUrl)
                      .To(vm => vm.PosterPath);
            bindingSet.Bind(TitleLabel)
                      .To(vm => vm.Title); 
            bindingSet.Bind(OverviewLabel)
                      .To(vm => vm.Overview);
           /* var source = new MvxCollectionViewSource(LanguagesCollectionView, LanguageCollectionViewCell.Key);
            bindingSet.Bind(source)
                      .To(vm => vm.AvailableLanguages);
            LanguagesCollectionView.Source = source;*/

            bindingSet.Bind(ReleaseDateLabel)
                      .To(vm => vm.RelaseDate);

            bindingSet.Bind(GenresLabel)
                      .To(vm => vm.Genres);

            bindingSet.Apply();
            TitleLabel.SizeToFit();
            //LanguagesCollectionView.ReloadData();
        }

        public override void LayoutSubviews()
        {
            SelectionStyle = UITableViewCellSelectionStyle.None;
            var layout = new UICollectionViewFlowLayout
            {
                MinimumLineSpacing = 2,
                MinimumInteritemSpacing = 2
            };
            //LanguagesCollectionView.CollectionViewLayout = layout;
            base.LayoutSubviews();
        }
    }
}
