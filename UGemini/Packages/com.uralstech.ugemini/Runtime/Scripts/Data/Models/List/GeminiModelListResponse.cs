using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models
{
    /// <summary>
    /// The response for a <see cref="GeminiModelListRequest"/> call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiModelListResponse
    {
        /// <summary>
        /// The list of models.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiModel[] Models;

        /// <summary>
        /// A token that can be sent as a <see cref="GeminiModelListRequest.PageToken"/> into a subsequent <see cref="GeminiModelListRequest"/> call.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken;
    }
}
