using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever
{
    /// <summary>
    /// Defines the valid operators that can be applied to a key-value pair.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiMetadataConditionOperator
    {
        /// <summary>
        /// The default value. This value is unused.
        /// </summary>
        [EnumMember(Value = "OPERATOR_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Supported by numeric.
        /// </summary>
        [EnumMember(Value = "LESS")]
        LessThan,

        /// <summary>
        /// Supported by numeric.
        /// </summary>
        [EnumMember(Value = "LESS_EQUAL")]
        LessThanOrEqual,

        /// <summary>
        /// Supported by numeric and string.
        /// </summary>
        [EnumMember(Value = "EQUAL")]
        Equal,

        /// <summary>
        /// Supported by numeric.
        /// </summary>
        [EnumMember(Value = "GREATER_EQUAL")]
        GreaterThanOrEqual,

        /// <summary>
        /// Supported by numeric.
        /// </summary>
        [EnumMember(Value = "GREATER")]
        GreaterThan,

        /// <summary>
        /// Supported by numeric and string.
        /// </summary>
        [EnumMember(Value = "NOT_EQUAL")]
        NotEqual,

        /// <summary>
        /// Supported by string only when CustomMetadata value type for the given key has a stringListValue.
        /// </summary>
        [EnumMember(Value = "INCLUDES")]
        Includes,

        /// <summary>
        /// Supported by string only when CustomMetadata value type for the given key has a stringListValue.
        /// </summary>
        [EnumMember(Value = "EXCLUDES")]
        Excludes,
    }
}
