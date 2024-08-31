using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Content
{
    /// <summary>
    /// URI based data.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileData
    {
        /// <summary>
        /// The IANA standard MIME type of the source data.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string MimeType = null;

        /// <summary>
        /// URI.
        /// </summary>
        public string FileUri;

        /// <summary>
        /// Creates a new <see cref="GeminiFileData"/> object.
        /// </summary>
        public GeminiFileData() { }

        /// <summary>
        /// Creates a new <see cref="GeminiFileData"/> object.
        /// </summary>
        /// <param name="contentType">The type of the file's contents.</param>
        /// <param name="fileUri">The URI to the file.</param>
        public GeminiFileData(GeminiContentType contentType, string fileUri)
        {
            MimeType = contentType.MimeType();
            FileUri = fileUri;
        }
    }
}