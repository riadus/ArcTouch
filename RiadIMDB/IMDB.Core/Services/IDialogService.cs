namespace IMDB.Core.Services
{
    public interface IDialogService
    {
        void ShowMessage(string message, bool removable, bool withSpinner);
        void Hide();
    }
}
