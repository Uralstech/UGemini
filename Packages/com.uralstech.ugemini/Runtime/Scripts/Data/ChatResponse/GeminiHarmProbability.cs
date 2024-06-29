using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.GeminiAPI.Data.ChatResponse
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiHarmProbability
    {
        [EnumMember(Value = "HARM_PROBABILITY_UNSPECIFIED")]
        Unspecified,

        [EnumMember(Value = "NEGLIGIBLE")]
        Negligible,

        [EnumMember(Value = "LOW")]
        Low,

        [EnumMember(Value = "MEDIUM")]
        Medium,

        [EnumMember(Value = "HIGH")]
        High,
    }
}