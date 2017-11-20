using System.Threading.Tasks;

namespace IMDB.Domain.Interfaces
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string url, string lang = "", int page = 1);
        Task<byte[]> GetImage(string url);
    }
}
