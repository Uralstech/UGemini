using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Safety
{
    /// <summary>
    /// Specifies what was the reason why prompt was blocked.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiBlockReason
    {
        /// <summary>
        /// Default value. This value is unused.
        /// </summary>
        [EnumMember(Value = "BLOCK_REASON_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Prompt was blocked due to safety reasons. You can inspect <see cref="Candidate.GeminiPromptFeedback.SafetyRatings"/> to understand which safety category blocked it.
        /// </summary>
        [EnumMember(Value = "SAFETY")]
        Safety,

        /// <summary>
        /// Prompt was blocked due to unknown reasons.
        /// </summary>
        [EnumMember(Value = "OTHER")]
        Other,

        /// <summary>
        /// Prompt was blocked due to the terms which are included from the terminology blocklist.
        /// </summary>
        [EnumMember(Value = "BLOCKLIST")]
        BlockList,

        /// <summary>
        /// Prompt was blocked due to prohibited content.
        /// </summary>
        [EnumMember(Value = "PROHIBITED_CONTENT")]
        ProhibitedContent,
    }
}