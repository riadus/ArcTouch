using System.Threading.Tasks;
using IMDB.Data;
using static IMDB.Core.Services.NavigationService;

namespace IMDB.Core.ViewModels
{
    public class IncomingMoviesViewModel : BaseViewModel
    {
        public Task Init(NavigationObject navigationObject)
        {
            return base.Initialize();
        }
    }
}
