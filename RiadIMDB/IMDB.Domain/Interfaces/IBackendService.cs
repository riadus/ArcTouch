using System.Collections.Generic;
using System.Threading.Tasks;
using IMDB.Data;

namespace IMDB.Domain.Interfaces
{
    public interface IBackendService
    {
        Task<IEnumerable<Movie>> GetMovies(string filmFilter);
        Task<IEnumerable<Movie>> GetMoreMovies(string filmFilter);
    }
}
