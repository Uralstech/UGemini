using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Metadata about the state and progress of creating a tuned model returned from the long-running operation
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelCreationOperationMetadata
    {
        /// <summary>
        /// The ID of the model being tuned.
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdStringConverter))]
        public GeminiModelId TunedModel;

        /// <summary>
        /// The total number of tuning steps.
        /// </summary>
        public int TotalSteps;

        /// <summary>
        /// The number of steps completed.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? CompletedSteps = null;

        /// <summary>
        /// The completed percentage for the tuning operation.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? CompletedPercent = null;

        /// <summary>
        /// Metrics collected during tuning.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiTuningSnapshot[] Snapshots = null;
    }
}