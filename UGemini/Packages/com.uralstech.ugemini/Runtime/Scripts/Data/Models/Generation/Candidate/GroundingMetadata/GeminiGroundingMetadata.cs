using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Metadata returned to client when grounding is enabled.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingMetadata
    {
        /// <summary>
        /// List of supporting references retrieved from specified grounding source.
        /// </summary>
        public GeminiGroundingChunk[] GroundingChunks;

        /// <summary>
        /// List of grounding support.
        /// </summary>
        public GeminiGroundingSupport[] GroundingSupports;

        /// <summary>
        /// Web search queries for the following-up web search.
        /// </summary>
        public string[] WebSearchQueries;

        /// <summary>
        /// Google search entry for the following-up web searches.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiSearchEntryPoint SearchEntryPoint = null;

        /// <summary>
        /// Metadata related to retrieval in the grounding flow.
        /// </summary>
        public GeminiRetrievalMetadata RetrievalMetadata;
    }
}
