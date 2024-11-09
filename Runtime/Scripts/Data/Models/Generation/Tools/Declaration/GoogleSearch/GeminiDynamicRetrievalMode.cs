using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration.GoogleSearch
{
    /// <summary>
    /// The mode of the predictor to be used in dynamic retrieval.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiDynamicRetrievalMode
    {
        /// <summary>
        /// Always trigger retrieval
        /// </summary>
        [EnumMember(Value = "MODE_UNSPECIFIED")]
        AlwaysTrigger,

        /// <summary>
        /// Run retrieval only when system decides it is necessary.
        /// </summary>
        [EnumMember(Value = "MODE_DYNAMIC")]
        Dynamic,
    }
}