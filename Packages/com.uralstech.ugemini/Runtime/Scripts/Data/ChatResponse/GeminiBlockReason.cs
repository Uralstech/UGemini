using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.GeminiAPI.Data.ChatResponse
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiBlockReason
    {
        [EnumMember(Value = "BLOCK_REASON_UNSPECIFIED")]
        Unspecified,

        [EnumMember(Value = "SAFETY")]
        Safety,

        [EnumMember(Value = "OTHER")]
        Other,
    }
}