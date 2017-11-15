using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using IMDB.Core.ViewModels.Dialogs;

namespace RiadIMDB.iOS
{
    public partial class DialogMessageView : MvxView
    {
        public DialogMessageView(IntPtr handle) : base(handle)
        {
        }

        public void SetDataContext(object dataContext)
        {
            DataContext = dataContext;
            SetBindings();
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<DialogMessageView, DialogMessageViewModel>();
            bindingSet.Bind(MessageLabel)
                      .To(vm => vm.Message);
            bindingSet.Bind(LoadingIndicator)
                      .For(li => li.Hidden)
                      .To(vm => vm.Removable);
            LoadingIndicator.StartAnimating();
            bindingSet.Apply();

            var viewModel = DataContext as DialogMessageViewModel;
            if (!viewModel?.Removable ?? true)
            {
                return;
            }

            AddGestureRecognizer(new UITapGestureRecognizer(RemoveFromSuperview));
        }

        public override void LayoutSubviews()
        {
            MessageLabel.LineBreakMode = UILineBreakMode.WordWrap;
            MessageLabel.Lines = 0;
            MessageLabel.TextAlignment = UITextAlignment.Center;
            base.LayoutSubviews();
        }
    }
}