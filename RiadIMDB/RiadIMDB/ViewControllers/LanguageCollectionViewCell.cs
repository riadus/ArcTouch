using System;

using Foundation;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using RiadIMDB.iOS.Converters;
using UIKit;

namespace RiadIMDB.iOS.Views
{
    public partial class LanguageCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("LanguageCollectionViewCell");
        public static readonly UINib Nib;
        private MvxImageViewLoader _imageViewLoader;

        static LanguageCollectionViewCell()
        {
            Nib = UINib.FromName("LanguageCollectionViewCell", NSBundle.MainBundle);
        }

        protected LanguageCollectionViewCell(IntPtr handle) : base(handle)
        {
            _imageViewLoader = new MvxImageViewLoader(() => FlagImage);
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<LanguageCollectionViewCell, LanguageViewModel>();
            bindingSet.Bind(_imageViewLoader)
                      .For(i => i.ImageUrl).
                      To(vm => vm.Language)
                      .WithConversion(new ImagePathConverter());
            bindingSet.Apply();
        }
    }
}
