using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Metadata for a <see cref="GeminiFile"/> to be uploaded.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileUploadMetaData
    {
        /// <summary>
        /// The <see cref="GeminiFileUploadRequest"/> resource name, in format "files/{fileId}".
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "files/" prefix) can contain up to 40 characters that are lowercase alphanumeric or dashes (-).<br/>
        /// The ID cannot start or end with a dash. If the name is empty on create, a unique name will be generated. Example: files/123-456
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Name = null;

        /// <summary>
        /// The human-readable display name for the <see cref="GeminiFileUploadRequest"/>. The display name must be no more than 512 characters in length, including spaces. Example: "Welcome Image"
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;
    }
}
