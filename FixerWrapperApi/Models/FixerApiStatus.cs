using System.Text.Json.Serialization;

namespace FixerWrapperApi.Models
{
    public class FixerApiStatus
    {
        public bool Success { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }

        public string Info { get; set; }
    }
}