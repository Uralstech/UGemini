
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Uralstech.GeminiAPI.Data
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiContentType
    {
        [EnumMember(Value = "image/png")]
        ImagePNG,

        [EnumMember(Value = "image/jpeg")]
        ImageJPEG,

        [EnumMember(Value = "image/heic")]
        ImageHEIC,

        [EnumMember(Value = "image/heif")]
        ImageHEIF,

        [EnumMember(Value = "image/webp")]
        ImageWebP
    }
}