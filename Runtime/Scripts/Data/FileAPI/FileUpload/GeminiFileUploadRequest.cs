using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Uploads a file to the Gemini File API. Response type is <see cref="GeminiFileUploadResponse"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileUploadRequest : IGeminiPostRequest
    {
        // /// <summary>
        // /// The <see cref="GeminiFileUploadRequest"/> resource name.
        // /// </summary>
        // /// <remarks>
        // /// The ID (name excluding the "files/" prefix) can contain up to 40 characters that are lowercase alphanumeric or dashes (-).<br/>
        // /// The ID cannot start or end with a dash. If the name is empty on create, a unique name will be generated. Example: files/123-456
        // /// </remarks>
        // public string Name;

        // /// <summary>
        // /// The human-readable display name for the <see cref="GeminiFileUploadRequest"/>. The display name must be no more than 512 characters in length, including spaces. Example: "Welcome Image"
        // /// </summary>
        // [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        // public string DisplayName = null;

        /// <summary>
        /// The IANA standard MIME type of the <see cref="GeminiFileUploadRequest"/>.
        /// </summary>
        /// <remarks>
        /// You can use <see cref="EnumExtensions.MimeType(GeminiContentType)"/> to convert <see cref="GeminiContentType"/>
        /// values to their <see cref="string"/> MIME type, like:
        /// <c>GeminiContentType.ImagePNG.MimeType()</c>
        /// </remarks>
        [JsonIgnore]
        public string MimeType;

        /// <summary>
        /// The raw file data to upload.
        /// </summary>
        [JsonIgnore]
        public byte[] RawData;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <inheritdoc/>
        [JsonIgnore]
        public string ContentType { get; }

        /// <inheritdoc/>
        [JsonIgnore]
        public string EndpointUri => $"https://generativelanguage.googleapis.com/upload/{ApiVersion}/files";

        /// <summary>
        /// Creates a new <see cref="GeminiFileUploadRequest"/>.
        /// </summary>
        /// <param name="contentType">The content type of the data</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiFileUploadRequest(string contentType, bool useBetaApi = true)
        {
            ContentType = contentType;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return Encoding.UTF8.GetString(RawData);
        }
    }
}
