using FixerWrapperApi.Extensions;
using System.Text.Json;

namespace FixerWrapperApi.Services.Http
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null) where T : new()
        {
            HttpRequestMessage httpRequestMessage = new(HttpMethod.Get, url);

            httpRequestMessage.AddRequestHeaders(headers);

            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            using Stream contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            T response = await JsonSerializer.DeserializeAsync
               <T>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response;
        }

        public async Task<T> PostAsync<T>(string url, HttpContent httpContent, Dictionary<string, string> headers = null) where T : new()
        {
            HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, url)
            {
                Content = httpContent
            };

            httpRequestMessage.AddRequestHeaders(headers);

            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            using Stream contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            T response = await JsonSerializer.DeserializeAsync
               <T>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response;
        }
    }
}
