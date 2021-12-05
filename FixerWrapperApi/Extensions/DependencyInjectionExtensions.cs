using FixerWrapperApi.Services.ExchangeRates;

namespace FixerWrapperApi.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IExchangeRatesService, ExchangeRatesService>();
        }
    }
}
