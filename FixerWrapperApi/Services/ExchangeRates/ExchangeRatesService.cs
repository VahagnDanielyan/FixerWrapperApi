using FixerWrapperApi.Models;
using FixerWrapperApi.Services.Http;

namespace FixerWrapperApi.Services.ExchangeRates
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private const string GetLatestUri = "/latest";
        private readonly IHttpService _httpservice;
        private readonly IConfiguration _configuration;

        public ExchangeRatesService(IHttpService httpservice, IConfiguration configuration)
        {
            _httpservice = httpservice;
            _configuration = configuration;
        }

        public async Task<ExchangeRate> GetExchangeRatesAsync()
        {
            string url = $"{GetLatestUri}?access_key={_configuration["FixerApiKey"]}&symbols=USD,AUD,CAD,PLN,MXN";
            ExchangeRate exchangeRate = await _httpservice.GetAsync<ExchangeRate>(url);

            return exchangeRate;
        }
    }
}
