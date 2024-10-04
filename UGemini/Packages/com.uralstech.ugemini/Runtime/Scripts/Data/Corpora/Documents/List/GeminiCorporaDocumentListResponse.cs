using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// The response for a <see cref="GeminiCorporaListRequest"/> call for listing Documents.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaDocumentListResponse
    {
        /// <summary>
        /// The list of Documents.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiCorpusDocument[] Documents;

        /// <summary>
        /// A token that can be sent as a <see cref="GeminiCorporaListRequest.PageToken"/> into a subsequent <see cref="GeminiCorporaListRequest"/> call.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken;
    }
}
