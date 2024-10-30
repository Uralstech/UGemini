using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Request to delete a Chunk. Part of multiple requests in a <see cref="GeminiCorporaChunkBatchDeleteRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchDeleteRequestPart
    {
        /// <summary>
        /// The resource name of the Chunk to delete.
        /// </summary>
        [JsonProperty("name"), JsonConverter(typeof(GeminiCorpusResourceIdToStringConverter<GeminiCorpusChunkId>))]
        public GeminiCorpusChunkId ChunkId;
    }
}
