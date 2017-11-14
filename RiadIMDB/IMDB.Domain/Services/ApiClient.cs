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
        private const string Token = "1f54bd990f1cdfb230adb312546d765d";
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };
        }

        private string ApplyToken(string url)
        {
            if(!url.Contains("?"))
            {
                url += "?";
            }
            url += $"api_key={Token}";
            return url;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var urlWithToken = ApplyToken(url);
            var request = new HttpRequestMessage(HttpMethod.Get, urlWithToken);

            try
            {
                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var deserializedObject = JsonConvert.DeserializeObject<T>(content);
                    return deserializedObject;
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
    }
}
