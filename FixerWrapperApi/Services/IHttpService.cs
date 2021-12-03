using FixerWrapperApi.Models;

namespace FixerWrapperApi.Services
{
    public interface IHttpService
    {
        Task<ExchangeRate> GetExchangeRatesAsync();
    }
}