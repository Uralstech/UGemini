using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// The information for a chunk relevant to a query.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpusRelevantChunk
    {
        /// <summary>
        /// Chunk relevance to the query.
        /// </summary>
        public float ChunkRelevanceScore;

        /// <summary>
        /// Chunk associated with the query.
        /// </summary>
        public GeminiCorpusChunk Chunk;
    }
}
