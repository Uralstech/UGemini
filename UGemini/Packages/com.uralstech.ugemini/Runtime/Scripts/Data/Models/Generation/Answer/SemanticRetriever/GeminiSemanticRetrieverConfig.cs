using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.Models.Content;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever
{
    /// <summary>
    /// Configuration for retrieving grounding content from a Corpus or Document created using the Semantic Retriever API.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSemanticRetrieverConfig
    {
        /// <summary>
        /// Name of the resource for retrieval, e.g. corpora/123 or corpora/123/documents/abc.
        /// </summary>
        public string Source;

        /// <summary>
        /// Query to use for similarity matching Chunks in the given resource.
        /// </summary>
        public GeminiContent Query;

        /// <summary>
        /// Filters for selecting Documents and/or Chunks from the resource.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiMetadataFilter[] MetadataFilters = null;

        /// <summary>
        /// Maximum number of relevant Chunks to retrieve.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1)]
        public int MaxChunksCount = -1;

        /// <summary>
        /// Minimum relevance score for retrieved relevant Chunks.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1f)]
        public float MinimumRelevanceScore = -1f;
    }
}
