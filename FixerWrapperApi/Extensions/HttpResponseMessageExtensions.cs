namespace FixerWrapperApi.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static void AddRequestHeaders(this HttpRequestMessage httpRequestMessage, Dictionary<string, string> headers)
        {
            if (headers.IsNullOrEmpty() == false)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    httpRequestMessage.Headers.Add(header.Key, header.Value);
                }
            }
        }
    }
}
