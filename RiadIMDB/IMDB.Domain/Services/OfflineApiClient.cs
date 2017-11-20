using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using IMDB.Domain.Attributes;
using IMDB.Domain.DTOs;
using IMDB.Domain.Interfaces;
using Newtonsoft.Json;

namespace IMDB.Domain.Services
{
    public class OfflineApiClient : IApiClient
    {
        public async Task<T> GetAsync<T>(string url, string lang = "", int page = 1)
        {
            if (typeof(T) == typeof(MoviesApiResponse))
            {
                return await ReadJsonResource<T>().ConfigureAwait(false);
            }
            return default(T);
        }

        public Task<byte[]> GetImage(string url)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostAsync<TResponse, TContent>(string url, TContent content)
        {
            throw new NotImplementedException();
        }

        async Task<T> ReadJsonResource<T>()
        {
            var assembly = typeof(OfflineApiClient).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"IMDB.Domain.Fixed.UpcomingMovies.json");

            if (stream == null)
            {
                return default(T);
            }
            string text;
            using (var reader = new StreamReader(stream))
            {
                text = await reader.ReadToEndAsync().ConfigureAwait(false);
            }
            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}
