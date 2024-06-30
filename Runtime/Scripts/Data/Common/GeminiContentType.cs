
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Uralstech.UGemini
{
    /// <summary>
    /// Enum for the types of content able to be fed to the Gemini API.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiContentType
    {
        /// <summary>
        /// A PNG image.
        /// </summary>
        [EnumMember(Value = "image/png")]
        ImagePNG,

        /// <summary>
        /// A JPEG image.
        /// </summary>
        [EnumMember(Value = "image/jpeg")]
        ImageJPEG,

        /// <summary>
        /// A HEIC image.
        /// </summary>
        [EnumMember(Value = "image/heic")]
        ImageHEIC,

        /// <summary>
        /// A HEIF image.
        /// </summary>
        [EnumMember(Value = "image/heif")]
        ImageHEIF,

        /// <summary>
        /// A WebP image.
        /// </summary>
        [EnumMember(Value = "image/webp")]
        ImageWebP
    }
}