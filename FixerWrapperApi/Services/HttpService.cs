using FixerWrapperApi.Models;
using System.Net.Http;
using System.Text.Json;

namespace FixerWrapperApi.Services
{
    public class HttpService : IHttpService
    {
        private const string GetLatestUri = "/latest";
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpService(HttpClient httpClient, IConfiguration configuration)
        {
            //_httpClientFactory = httpClientFactory;
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(configuration["FixerBaseUrl"]);
        }

        public async Task<ExchangeRate> GetExchangeRatesAsync()
        {
            ExchangeRate exchangeRate = new();
            HttpRequestMessage httpRequestMessage = new(HttpMethod.Get, $"{GetLatestUri}?access_key={_configuration["FixerApiKey"]}&symbols=USD,AUD,CAD,PLN,MXN");
            //HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            using Stream contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                exchangeRate = await JsonSerializer.DeserializeAsync
                   <ExchangeRate>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return exchangeRate;
        }
    }
}
