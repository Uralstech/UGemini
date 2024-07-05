using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Uploads a file to the Gemini File API. Response type is <see cref="GeminiFileUploadResponse"/>.
    /// </summary>
    /// <remarks>
    /// This feature is currently being worked on and is unstable.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFileUploadRequest : IGeminiMultiPartPostRequest
    {
        /// <summary>
        /// Metadata for the <see cref="GeminiFile"/> to be uploaded.
        /// </summary>
        public GeminiFileUploadMetaData File;

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
        public string GetUtf8EncodedData(string dataSeperator)
        {
            StringBuilder data = new($"--{dataSeperator}\r\n");

            data.Append("Content-Disposition: form-data; name=\"metadata\"\r\n");
            data.Append("Content-Type: application/json; charset=UTF-8\r\n\r\n");
            data.Append($"{JsonConvert.SerializeObject(this)}\r\n");

            data.Append($"--{dataSeperator}\r\n");
            data.Append("Content-Disposition: form-data; name=\"file\"\r\n");
            data.Append($"Content-Type: {ContentType}\r\n\r\n");
            data.Append($"{Encoding.UTF8.GetString(RawData)}\r\n");
            data.Append($"--{dataSeperator}--\r\n");

            return data.ToString();
        }
    }
}
