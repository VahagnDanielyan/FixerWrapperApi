using System.Text.Json.Serialization;

namespace FixerWrapperApi.Models
{
    public class Status
    {
        public bool Success { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        [JsonPropertyName("info")]
        public string Info { get; set; }
    }
}