using FixerWrapperApi.Services;

namespace FixerWrapperApi.Extensions
{
    public static class HttpClientExtension
    {
        public static void AddHttpClients(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddHttpClient<IHttpService, HttpService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(configuration["FixerBaseUrl"]);
            });
        }
    }
}
