using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using IMDB.Domain.Attributes;
using IMDB.Domain.Interfaces;
using Newtonsoft.Json;

namespace IMDB.Domain.Services
{
    [RegisterInterfaceAsLazySingleton]
    public class ApiClient : IApiClient
    {
        private const string BaseAddress = "https://api.themoviedb.org/3/";
        private const string ImageBaseAddress = "http://image.tmdb.org/";

        private const string Token = "1f54bd990f1cdfb230adb312546d765d";
        private readonly HttpClient _httpClient;
        private readonly HttpClient _imageHttpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };
            _imageHttpClient = new HttpClient()
            {
                BaseAddress = new Uri(ImageBaseAddress)
            };
        }

        private string ApplyTokenAndLanguage(string url, string lang)
        {
            url += $"?api_key={Token}";
            if(!string.IsNullOrEmpty(lang))
            {
                url += $"&language={lang}";
            }
            return url;
        }

        public async Task<T> GetAsync<T>(string url, string lang = "")
        {
            var urlWithToken = ApplyTokenAndLanguage(url, lang);
            var response = await GetContent(_httpClient, urlWithToken);
            var content = await response.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<T>(content);
            return deserializedObject;
        }

        private async Task<HttpResponseMessage> GetContent(HttpClient httpClient, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            try
            {
                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                throw new ApiException("Something wrong happened with the API", response.StatusCode);
            }
            catch (TaskCanceledException tce)
            {
                Debug.WriteLine($"request {url} timed out");
                throw new HttpRequestException("Request timed out", tce);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HttpClient Get request {url} exception {ex}");
                throw;
            }
        }

        public Task<TResponse> PostAsync<TResponse, TContent>(string url, TContent content)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetImage(string url)
        {
            var response = await GetContent(_imageHttpClient, $"t/p/w150/{url}");
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
