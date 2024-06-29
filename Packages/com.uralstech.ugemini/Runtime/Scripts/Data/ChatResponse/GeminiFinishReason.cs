using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.GeminiAPI.Data.ChatResponse
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiFinishReason
    {
        [EnumMember(Value = "FINISH_REASON_UNSPECIFIED")]
        Unspecified,

        [EnumMember(Value = "STOP")]
        Stop,

        [EnumMember(Value = "MAX_TOKENS")]
        MaxTokens,

        [EnumMember(Value = "SAFETY")]
        Safety,

        [EnumMember(Value = "RECITATION")]
        Recitation,

        [EnumMember(Value = "OTHER")]
        Other,
    }
}