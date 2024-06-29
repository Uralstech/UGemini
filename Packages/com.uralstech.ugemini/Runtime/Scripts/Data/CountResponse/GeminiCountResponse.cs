using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Uralstech.GeminiAPI.Data.CountResponse
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCountResponse
    {
        public int TotalTokens;
    }
}