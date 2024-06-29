using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.GeminiAPI.Data.ChatResponse
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCitationSource
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int StartIndex;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int EndIndex;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Uri;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string License;
    }
}