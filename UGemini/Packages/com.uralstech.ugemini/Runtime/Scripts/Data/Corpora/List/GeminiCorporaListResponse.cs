using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// The response for a <see cref="GeminiCorporaListRequest"/> call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaListResponse
    {
        /// <summary>
        /// The list of corpora.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiCorpus[] Corpora;

        /// <summary>
        /// A token that can be sent as a <see cref="GeminiCorporaListRequest.PageToken"/> into a subsequent <see cref="GeminiCorporaListRequest"/> call.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken;
    }
}
