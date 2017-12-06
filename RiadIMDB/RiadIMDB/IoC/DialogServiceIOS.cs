using Foundation;
using IMDB.Core.Services;
using IMDB.Core.ViewModels.Dialogs;
using RiadIMDB.iOS.Views;
using UIKit;

namespace RiadIMDB.iOS.IoC
{
    public class DialogServiceIOS : NSObject, IDialogService
    {
        private DialogMessageView _view;

        public void Hide()
        {
            BeginInvokeOnMainThread(() =>
            {
                _view.RemoveFromSuperview();
                _view = null;
            });
        }

        public void ShowMessage(string message, bool removable, bool withSpinner)
        {
            BeginInvokeOnMainThread(() =>
            {
                _view = ViewFactory.Create<DialogMessageView>("DialogMessageView");
                _view.SetDataContext(new DialogMessageViewModel(message, removable, withSpinner));
                UIApplication.SharedApplication.KeyWindow.RootViewController.Add(_view);
            });
        }
    }
}
