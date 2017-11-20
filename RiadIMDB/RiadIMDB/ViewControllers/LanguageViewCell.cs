using System;
using Foundation;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using RiadIMDB.iOS.Converters;
using UIKit;

namespace RiadIMDB.iOS.ViewControllers
{
    public partial class LanguageViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("LanguageViewCell");
        public static readonly UINib Nib;
        private MvxImageViewLoader _imageViewLoader;
        static LanguageViewCell()
        {
            Nib = UINib.FromName("LanguageViewCell", NSBundle.MainBundle);
        }

        protected LanguageViewCell(IntPtr handle) : base(handle)
        {
            _imageViewLoader = new MvxImageViewLoader(() => FlagImage);
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<LanguageViewCell, LanguageViewModel>();
            bindingSet.Bind(_imageViewLoader)
                      .For(i => i.ImageUrl).
                      To(vm => vm.Language)
                      .WithConversion(new ImagePathConverter());
            bindingSet.Bind(ImageContainer)
                      .For(img => img.BackgroundColor)
                      .To(vm => vm.IsSelected)
                      .WithConversion(new BoolToColorConverter(UIColor.Gray, UIColor.White));
            bindingSet.Apply();
        }

        public override void LayoutSubviews()
        {
            SelectionStyle = UITableViewCellSelectionStyle.None;
            base.LayoutSubviews();
        }
    }
}
