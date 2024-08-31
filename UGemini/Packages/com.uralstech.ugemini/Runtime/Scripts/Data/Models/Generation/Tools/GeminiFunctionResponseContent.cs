using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools
{
    /// <summary>
    /// The response of a Gemini function call. Based on the Protocol Buffer <a href="https://protobuf.dev/reference/protobuf/google.protobuf/#struct">Struct</a> type.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFunctionResponseContent
    {
        /// <summary>
        /// The name of the function.
        /// </summary>
        public string Name;

        /// <summary>
        /// The actual JSON response data of the function.
        /// </summary>
        [JsonProperty("response")]
        public JObject ResponseData;
    }
}