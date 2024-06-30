using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Chat
{
    /// <summary>
    /// Defines the reason why the model stopped generating tokens.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiFinishReason
    {
        /// <summary>
        /// Default value. This value is unused.
        /// </summary>
        [EnumMember(Value = "FINISH_REASON_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Natural stop point of the model or provided stop sequence.
        /// </summary>
        [EnumMember(Value = "STOP")]
        Stop,

        /// <summary>
        /// The maximum number of tokens as specified in the request was reached.
        /// </summary>
        [EnumMember(Value = "MAX_TOKENS")]
        MaxTokens,

        /// <summary>
        /// The candidate content was flagged for safety reasons.
        /// </summary>
        [EnumMember(Value = "SAFETY")]
        Safety,

        /// <summary>
        /// The candidate content was flagged for recitation reasons.
        /// </summary>
        [EnumMember(Value = "RECITATION")]
        Recitation,

        /// <summary>
        /// Unknown reason.
        /// </summary>
        [EnumMember(Value = "OTHER")]
        Other,
    }
}