
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Uralstech.GeminiAPI.Data
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiRole
    {
        Unspecified,

        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "model")]
        Assistant,

        [EnumMember(Value = "function")]
        ToolResponse,
    }
}