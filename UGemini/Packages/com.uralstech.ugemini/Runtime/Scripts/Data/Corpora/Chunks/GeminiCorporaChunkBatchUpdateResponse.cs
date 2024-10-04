using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Response for a <see cref="GeminiCorporaChunkBatchCreateRequest"/> or <see cref="GeminiCorporaChunkBatchUpdateRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchUpdateResponse
    {
        /// <summary>
        /// The created/updated Chunks.
        /// </summary>
        public GeminiCorpusChunk[] Chunks;
    }
}
