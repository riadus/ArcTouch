namespace IMDB.Core.ViewModels.Dialogs
{
    public class DialogMessageViewModel : BaseViewModel
    {
        public DialogMessageViewModel(string message, bool removable)
        {
            Message = message;
            Removable = removable;
            IsLoading = !Removable;
        }

        public string Message { get; }
        public bool Removable { get; }
        public bool IsLoading { get; set; }
    }
}
