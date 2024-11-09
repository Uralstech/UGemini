using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration.GoogleSearch
{
    /// <summary>
    /// Describes the options to customize dynamic retrieval.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiDynamicRetrievalConfig
    {
        /// <summary>
        /// The mode of the predictor to be used in dynamic retrieval.
        /// </summary>
        public GeminiDynamicRetrievalMode Mode;

        /// <summary>
        /// The threshold to be used in dynamic retrieval. If not set, a system default value is used
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public float? DynamicThreshold = null;
    }
}