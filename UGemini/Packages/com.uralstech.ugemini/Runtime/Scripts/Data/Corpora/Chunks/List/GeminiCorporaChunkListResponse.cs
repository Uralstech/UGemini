using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// The response for a <see cref="GeminiCorporaListRequest"/> call for listing Chunks.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkListResponse
    {
        /// <summary>
        /// The list of Chunks.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiCorpusChunk[] Chunks;

        /// <summary>
        /// A token that can be sent as a <see cref="GeminiCorporaListRequest.PageToken"/> into a subsequent <see cref="GeminiCorporaListRequest"/> call.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken;
    }
}
