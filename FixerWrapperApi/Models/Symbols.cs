using System.Text.Json.Serialization;

namespace FixerWrapperApi.Models
{
    public class Symbols
    {
        [JsonPropertyName("symbols")]
        public Dictionary<string, string> SupportedSymbols { get; set; }

        public bool IsValid(string symbol)
        {
            return SupportedSymbols.ContainsKey(symbol.ToUpper());
        }
    }
}