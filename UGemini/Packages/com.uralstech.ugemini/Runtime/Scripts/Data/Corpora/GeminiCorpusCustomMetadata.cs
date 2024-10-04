using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// User provided metadata stored as key-value pairs.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpusCustomMetadata
    {
        /// <summary>
        /// The key of the metadata to store.
        /// </summary>
        public string Key;

        /// <summary>
        /// The string value of the metadata to store.
        /// </summary>
        /// <remarks>
        /// Only one of <see cref="StringValue"/>, <see cref="StringListValue"/><br/>
        /// or <see cref="NumericValue"/> must be provided at a time.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string StringValue = null;

        /// <summary>
        /// The StringList value of the metadata to store.
        /// </summary>
        /// <remarks>
        /// Only one of <see cref="StringValue"/>, <see cref="StringListValue"/><br/>
        /// or <see cref="NumericValue"/> must be provided at a time.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusCustomMetadataStringList StringListValue = null;

        /// <summary>
        /// The numeric value of the metadata to store.
        /// </summary>
        /// <remarks>
        /// Only one of <see cref="StringValue"/>, <see cref="StringListValue"/><br/>
        /// or <see cref="NumericValue"/> must be provided at a time.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public float? NumericValue = null;
    }
}