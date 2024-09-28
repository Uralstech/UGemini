using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// The response for a <see cref="GeminiTunedModelListRequest"/> call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelListResponse
    {
        /// <summary>
        /// The list of tuned models.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiTunedModel[] TunedModels;

        /// <summary>
        /// A token that can be sent as a <see cref="GeminiModelListRequest.PageToken"/> into a subsequent <see cref="GeminiModelListRequest"/> call.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken;
    }
}
