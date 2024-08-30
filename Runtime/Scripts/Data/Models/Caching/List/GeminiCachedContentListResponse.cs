using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// The response for a <see cref="GeminiCachedContentListRequest"/> call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCachedContentListResponse
    {
        /// <summary>
        /// The list of cached contents.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiCachedContent[] CachedContents = null;

        /// <summary>
        /// A token that can be sent as a <see cref="GeminiCachedContentListRequest.PageToken"/> into a subsequent <see cref="GeminiCachedContentListRequest"/> call.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken = null;
    }
}
