using MvvmCross.Core.ViewModels;

namespace IMDB.Core.ViewModels.Dialogs
{
    public class DialogMessageViewModel : MvxViewModel
    {
        public DialogMessageViewModel(string message, bool removable, bool withSpinner)
        {
            Message = message;
            Removable = removable;
            IsLoading = withSpinner;
        }

        public string Message { get; }
        public bool Removable { get; }
        public bool IsLoading { get; }
    }
}
