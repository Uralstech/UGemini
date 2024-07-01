using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini
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
        /// <remarks>
        /// You can use <see cref="EnumExtensions.MimeType(GeminiContentType)"/> to convert <see cref="GeminiContentType"/>
        /// values to their <see cref="string"/> MIME type, like:
        /// <c>GeminiContentType.ImagePNG.MimeType()</c>
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string MimeType = null;

        /// <summary>
        /// URI.
        /// </summary>
        public string FileUri;
    }
}