using FixerWrapperApi.Models;
using FixerWrapperApi.Services.Http;

namespace FixerWrapperApi.Services.ExchangeRates
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private const string GetLatestUri = "/latest";
        private const string SupportedSymbolsUri = "/symbols";
        private readonly IHttpService _httpservice;
        private readonly IConfiguration _configuration;

        public ExchangeRatesService(IHttpService httpservice, IConfiguration configuration)
        {
            _httpservice = httpservice;
            _configuration = configuration;
        }

        public async Task<ExchangeRate> GetExchangeRatesAsync(string baseCurrency)
        {
            string url = $"{GetLatestUri}?access_key={_configuration["FixerApiKey"]}&base={baseCurrency}";
            ExchangeRate exchangeRate = await _httpservice.GetAsync<ExchangeRate>(url);

            return exchangeRate;
        }

        public async Task<Symbols> GetSupportedSymbolsAsync()
        {
            string url = $"{SupportedSymbolsUri}?access_key={_configuration["FixerApiKey"]}";
            Symbols symbols = await _httpservice.GetAsync<Symbols>(url);

            return symbols;
        }
    }
}
