using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering
{
    /// <summary>
    /// Style for grounded answers.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiAnswerStyle
    {
        /// <summary>
        /// Unspecified answer style.
        /// </summary>
        [EnumMember(Value = "ANSWER_STYLE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Succint but abstract style.
        /// </summary>
        [EnumMember(Value = "ABSTRACTIVE")]
        Abstractive,

        /// <summary>
        /// Very brief and extractive style.
        /// </summary>
        [EnumMember(Value = "EXTRACTIVE")]
        Extractive,

        /// <summary>
        /// Verbose style including extra details. The response may be formatted as a sentence, paragraph, multiple paragraphs, or bullet points, etc.
        /// </summary>
        [EnumMember(Value = "VERBOSE")]
        Verbose,
    }
}
