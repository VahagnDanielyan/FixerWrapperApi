namespace FixerWrapperApi.Models
{
    public class ExchangeRate : FixerApiStatus
    {
        public int Timestamp { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}