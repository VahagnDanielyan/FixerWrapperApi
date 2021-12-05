namespace FixerWrapperApi.Services.Http
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null) where T : new();
        Task<T> PostAsync<T>(string url, HttpContent httpContent, Dictionary<string, string> headers = null) where T : new();
    }
}