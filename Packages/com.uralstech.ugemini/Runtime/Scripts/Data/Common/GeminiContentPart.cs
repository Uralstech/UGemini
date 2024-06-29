using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Uralstech.GeminiAPI.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContentPart
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiContentBlob InlineData;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiFunctionCall FunctionCall;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GeminiFunctionResponse FunctionResponse;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionCall
    {
        public string Name;

        [JsonProperty("args")]
        public JObject Arguments;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionResponse
    {
        public string Name;

        public GeminiFunctionResponseContent Response;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionResponseContent
    {
        public string Name;

        [JsonProperty("response")]
        public JObject ResponseData;
    }
}