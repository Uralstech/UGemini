using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Uralstech.UCloud.Operations;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.FileAPI
{
    /// <summary>
    /// Metadata for a file uploaded to the File API.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiFile
    {
        /// <summary>
        /// The <see cref="GeminiFile"/> resource name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The human-readable display name for the <see cref="GeminiFile"/>.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName = null;

        /// <summary>
        /// MIME type of the file.
        /// </summary>
        /// <remarks>
        /// You can use <see cref="GeminiContentTypeExtensions.ContentType(string)"/> to convert <see cref="string"/>
        /// values to their <see cref="GeminiContentType"/> equivalents, like:
        /// <c>"image/png".ContentType()</c>
        /// </remarks>
        public string MimeType;

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        [JsonConverter(typeof(GeminiLongToStringJsonConverter))]
        public long SizeBytes;

        /// <summary>
        /// The timestamp of when the <see cref="GeminiFile"/> was created.
        /// </summary>
        public DateTime CreateTime;

        /// <summary>
        /// The timestamp of when the <see cref="GeminiFile"/> was last updated.
        /// </summary>
        public DateTime UpdateTime;

        /// <summary>
        /// The timestamp of when the <see cref="GeminiFile"/> will be deleted. Only set if the <see cref="GeminiFile"/> is scheduled to expire.
        /// </summary>
        public DateTime ExpirationTime;

        /// <summary>
        /// SHA-256 hash of the uploaded bytes. A base64-encoded string.
        /// </summary>
        public string Sha256Hash;

        /// <summary>
        /// The uri of the <see cref="GeminiFile"/>.
        /// </summary>
        public string Uri;

        /// <summary>
        /// Processing state of the <see cref="GeminiFile"/>.
        /// </summary>
        public GeminiFileState State;

        /// <summary>
        /// Error status if <see cref="GeminiFile"/> processing failed.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public OperationStatus Error;

        /// <summary>
        /// Error status if <see cref="GeminiFile"/> processing failed.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore), Obsolete("Use GeminiFile.Error instead.")]
        public OperationStatus Status;

        /// <summary>
        /// Metadata for a video.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiFileVideoMetaData VideoMetadata;
    }
}
