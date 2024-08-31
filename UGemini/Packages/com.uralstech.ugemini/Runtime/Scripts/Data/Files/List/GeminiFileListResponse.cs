using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// The response for a <see cref="GeminiFileListRequest"/> call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileListResponse
    {
        /// <summary>
        /// The list of files.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiFile[] Files;

        /// <summary>
        /// A token that can be sent as a <see cref="GeminiFileListRequest.PageToken"/> into a subsequent <see cref="GeminiFileListRequest"/> call.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken;
    }
}
