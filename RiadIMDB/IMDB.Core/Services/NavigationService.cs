using IMDB.Core.ViewModels;
using IMDB.Domain.Attributes;
using MvvmCross.Core.ViewModels;

namespace IMDB.Core.Services
{
    [RegisterInterfaceAsDynamic]
    public class NavigationService : MvxNavigatingObject, INavigationService
    {
        public void ShowHomePage()
        {
            ShowViewModel<HomeViewModel>();
        }
    }
}
