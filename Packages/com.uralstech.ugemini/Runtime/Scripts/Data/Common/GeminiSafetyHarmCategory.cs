
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Uralstech.GeminiAPI.Data
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSafetyHarmCategory
    {
        [EnumMember(Value = "HARM_CATEGORY_UNSPECIFIED")]
        Unspecified,

        [EnumMember(Value = "HARM_CATEGORY_DEROGATORY")]
        Derogatory,

        [EnumMember(Value = "HARM_CATEGORY_TOXICITY")]
        Toxicity,

        [EnumMember(Value = "HARM_CATEGORY_VIOLENCE")]
        Violence,

        [EnumMember(Value = "HARM_CATEGORY_SEXUAL")]
        Sexual,

        [EnumMember(Value = "HARM_CATEGORY_MEDICAL")]
        Medical,

        [EnumMember(Value = "HARM_CATEGORY_DANGEROUS")]
        Dangerous,

        [EnumMember(Value = "HARM_CATEGORY_HARASSMENT")]
        Harassment,

        [EnumMember(Value = "HARM_CATEGORY_HATE_SPEECH")]
        HateSpeech,

        [EnumMember(Value = "HARM_CATEGORY_SEXUALLY_EXPLICIT")]
        SexuallyExplicit,

        [EnumMember(Value = "HARM_CATEGORY_DANGEROUS_CONTENT")]
        DangerousContent,
    }
}