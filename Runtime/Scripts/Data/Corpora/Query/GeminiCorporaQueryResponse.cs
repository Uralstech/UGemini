using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.CorporaAPI.Chunks;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// The response for a <see cref="GeminiCorporaQueryRequest"/> or <see cref="Documents.GeminiCorporaDocumentQueryRequest"/> call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaQueryResponse
    {
        /// <summary>
        /// The relevant chunks.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiCorpusRelevantChunk[] RelevantChunks;
    }
}
