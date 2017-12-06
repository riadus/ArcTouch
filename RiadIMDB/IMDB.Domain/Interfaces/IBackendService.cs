using System.Collections.Generic;
using System.Threading.Tasks;
using IMDB.Data;

namespace IMDB.Domain.Interfaces
{
    public interface IBackendService
    {
        Task<IEnumerable<Movie>> GetMovies(Language language);
        Task<IEnumerable<Movie>> GetMoreMovies(Language language);
        Task<Movie> GetMovieDetail(int id, Language language);
    }
}
