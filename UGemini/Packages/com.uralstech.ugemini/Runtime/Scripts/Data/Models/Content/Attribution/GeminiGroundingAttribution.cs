using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Content.Attribution
{
    /// <summary>
    /// Attribution for a source that contributed to an answer.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingAttribution
    {
        /// <summary>
        /// Identifier for the source contributing to this attribution.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiAttributionSourceId SourceId;

        /// <summary>
        /// Grounding source content that makes up this attribution.
        /// </summary>
        public GeminiContent Content;
    }
}