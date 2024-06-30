using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Chat
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
        /// Prompt was blocked due to safety reasons. You can inspect <see cref="GeminiPromptFeedback.SafetyRatings"/> to understand which safety category blocked it.
        /// </summary>
        [EnumMember(Value = "SAFETY")]
        Safety,

        /// <summary>
        /// Prompt was blocked due to unknown reasons.
        /// </summary>
        [EnumMember(Value = "OTHER")]
        Other,
    }
}