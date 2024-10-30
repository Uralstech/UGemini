using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.CorporaAPI.Documents;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Request to create a Chunk. Part of multiple requests in a <see cref="GeminiCorporaChunkBatchCreateRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchCreateRequestPart
    {
        /// <summary>
        /// The parent document in which the Chunk will be created.
        /// </summary>
        [JsonProperty("name"), JsonConverter(typeof(GeminiCorpusResourceIdToStringConverter<GeminiCorpusDocumentId>))]
        public GeminiCorpusDocumentId ParentDocumentId;

        /// <summary>
        /// Data about the Chunk to create.
        /// </summary>
        public GeminiCorporaChunkBatchCreationData Chunk;
    }
}
