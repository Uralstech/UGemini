using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Safety
{
    /// <summary>
    /// Block at and beyond a specified harm probability.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSafetyHarmBlockThreshold
    {
        /// <summary>
        /// Threshold is unspecified.
        /// </summary>
        [EnumMember(Value = "HARM_BLOCK_THRESHOLD_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Content with <see cref="GeminiHarmProbability.Negligible"/> will be allowed.
        /// </summary>
        [EnumMember(Value = "BLOCK_LOW_AND_ABOVE")]
        LowAndAbove,

        /// <summary>
        /// Content with <see cref="GeminiHarmProbability.Negligible"/> and <see cref="GeminiHarmProbability.Low"/> will be allowed.
        /// </summary>
        [EnumMember(Value = "BLOCK_MEDIUM_AND_ABOVE")]
        MediumAndAbove,

        /// <summary>
        /// Content with <see cref="GeminiHarmProbability.Negligible"/>, <see cref="GeminiHarmProbability.Low"/>, and <see cref="GeminiHarmProbability.Medium"/> will be allowed.
        /// </summary>
        [EnumMember(Value = "BLOCK_ONLY_HIGH")]
        OnlyHigh,

        /// <summary>
        /// All content will be allowed.
        /// </summary>
        [EnumMember(Value = "BLOCK_NONE")]
        None,

        /// <summary>
        /// Turn off the safety filter.
        /// </summary>
        [EnumMember(Value = "OFF")]
        Off,
    }
}