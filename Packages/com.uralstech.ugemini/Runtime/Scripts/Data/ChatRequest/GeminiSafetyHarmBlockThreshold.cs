
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Uralstech.GeminiAPI.Data.ChatRequest
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSafetyHarmBlockThreshold
    {
        [EnumMember(Value = "HARM_BLOCK_THRESHOLD_UNSPECIFIED")]
        Unspecified,

        [EnumMember(Value = "BLOCK_LOW_AND_ABOVE")]
        LowAndAbove,

        [EnumMember(Value = "BLOCK_MEDIUM_AND_ABOVE")]
        MediumAndAbove,

        [EnumMember(Value = "BLOCK_ONLY_HIGH")]
        OnlyHigh,

        [EnumMember(Value = "BLOCK_NONE")]
        None,
    }
}