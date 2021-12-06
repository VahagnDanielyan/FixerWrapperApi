using FixerWrapperApi.Models;

namespace FixerWrapperApi.Services.ExchangeRates
{
    public interface IExchangeRatesService
    {
        Task<ExchangeRate> GetExchangeRatesAsync(string baseCurrency);
        Task<Symbols> GetSupportedSymbolsAsync();
    }
}