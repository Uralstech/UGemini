using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever
{
    /// <summary>
    /// Filter condition applicable to a single key.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiMetadataCondition
    {
        /// <summary>
        /// Operator applied to the given key-value pair to trigger the condition.
        /// </summary>
        public GeminiMetadataConditionOperator Operation;

        /// <summary>
        /// The string value to filter the metadata on.
        /// </summary>
        /// <remarks>
        /// If this is provided, DO NOT provide <see cref="NumericValue"/>.
        /// <br/><br/>
        /// The value type must be consistent with the value type defined in the field for the corresponding key.<br/>
        /// If the value types are not consistent, the result will be an empty set. When the CustomMetadata has a<br/>
        /// StringList value type, the filtering condition should use <see cref="StringValue"/> paired<br/>
        /// with an <see cref="GeminiMetadataConditionOperator.Includes"/>/<see cref="GeminiMetadataConditionOperator.Excludes"/><br/>
        /// operation, otherwise the result will also be an empty set.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string StringValue = null;

        /// <summary>
        /// The numeric value to filter the metadata on.
        /// </summary>
        /// <remarks>
        /// If this is provided, DO NOT provide <see cref="StringValue"/>.
        /// <br/><br/>
        /// The value type must be consistent with the value type defined in the field for the corresponding key.<br/>
        /// If the value types are not consistent, the result will be an empty set. When the CustomMetadata has a<br/>
        /// StringList value type, the filtering condition should use <see cref="StringValue"/> paired<br/>
        /// with an <see cref="GeminiMetadataConditionOperator.Includes"/>/<see cref="GeminiMetadataConditionOperator.Excludes"/><br/>
        /// operation, otherwise the result will also be an empty set.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public float? NumericValue = null;
    }
}
