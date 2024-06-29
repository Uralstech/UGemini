using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Uralstech.GeminiAPI.Data.CountRequest
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCountRequest
    {
        public GeminiContent[] Contents;
    }
}