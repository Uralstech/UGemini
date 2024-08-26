using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Schema
{
    /// <summary>
    /// Contains the list of OpenAPI data types as defined by the <a href="https://spec.openapis.org/oas/v3.0.3#data-types">OpenAPI Specification</a>.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSchemaDataType
    {
        /// <summary>
        /// Not specified, should not be used.
        /// </summary>
        [EnumMember(Value = "TYPE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// String type.
        /// </summary>
        [EnumMember(Value = "STRING")]
        String,

        /// <summary>
        /// Number/Float type.
        /// </summary>
        [EnumMember(Value = "NUMBER")]
        Float,

        /// <summary>
        /// Integer type.
        /// </summary>
        [EnumMember(Value = "INTEGER")]
        Integer,

        /// <summary>
        /// Boolean type.
        /// </summary>
        [EnumMember(Value = "BOOLEAN")]
        Boolean,

        /// <summary>
        /// Array type.
        /// </summary>
        [EnumMember(Value = "ARRAY")]
        Array,

        /// <summary>
        /// Object type.
        /// </summary>
        [EnumMember(Value = "OBJECT")]
        Object,
    }
}