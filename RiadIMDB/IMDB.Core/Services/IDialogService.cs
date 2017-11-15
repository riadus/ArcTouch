namespace IMDB.Core.Services
{
    public interface IDialogService
    {
        void ShowMessage(string message, bool removable);
        void Hide();
    }
}
