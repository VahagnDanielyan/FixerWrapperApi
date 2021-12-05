using FixerWrapperApi.Services.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;

namespace FixerWrapperApi.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHttpClients(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddHttpClient<IHttpService, HttpService>(httpclient =>
            {
                httpclient.BaseAddress = new Uri(configuration["FixerBaseUrl"]);
                httpclient.DefaultRequestHeaders.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);
            });
        }
    }
}
