using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Safety
{
    /// <summary>
    /// The category of a rating.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSafetyHarmCategory
    {
        /// <summary>
        /// Category is unspecified.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Negative or harmful comments targeting identity and/or protected attribute.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_DEROGATORY")]
        Derogatory,

        /// <summary>
        /// Content that is rude, disrespectful, or profane.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_TOXICITY")]
        Toxicity,

        /// <summary>
        /// Describes scenarios depicting violence against an individual or group, or general descriptions of gore.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_VIOLENCE")]
        Violence,

        /// <summary>
        /// Contains references to sexual acts or other lewd content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_SEXUAL")]
        Sexual,

        /// <summary>
        /// Promotes unchecked medical advice.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_MEDICAL")]
        Medical,

        /// <summary>
        /// Dangerous content that promotes, facilitates, or encourages harmful acts.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_DANGEROUS")]
        Dangerous,

        /// <summary>
        /// Harasment content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_HARASSMENT")]
        Harassment,

        /// <summary>
        /// Hate speech and content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_HATE_SPEECH")]
        HateSpeech,

        /// <summary>
        /// Sexually explicit content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_SEXUALLY_EXPLICIT")]
        SexuallyExplicit,

        /// <summary>
        /// Dangerous content.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_DANGEROUS_CONTENT")]
        DangerousContent,

        /// <summary>
        /// Content that may be used to harm civic integrity.
        /// </summary>
        [EnumMember(Value = "HARM_CATEGORY_CIVIC_INTEGRITY")]
        CivicIntegrity,
    }
}