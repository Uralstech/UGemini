using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Content.Attribution
{
    /// <summary>
    /// Identifier for the source contributing to this attribution.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiAttributionSourceId
    {
        /// <summary>
        /// Identifier for an inline passage.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiGroundingPassageId GroundingPassage;

        /// <summary>
        /// Identifier for a Chunk fetched via Semantic Retriever.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiSemanticRetrieverChunk SemanticRetrieverChunk;
    }
}