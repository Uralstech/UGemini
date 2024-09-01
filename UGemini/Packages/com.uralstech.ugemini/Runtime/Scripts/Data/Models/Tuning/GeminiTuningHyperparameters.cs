using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Hyperparameters controlling the tuning process.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTuningHyperparameters
    {
        /// <summary>
        /// The learning rate hyperparameter for tuning. If not set, a default of 0.001 or 0.0002 will be calculated based on the number of training examples.
        /// </summary>
        /// <remarks>
        /// If <see langword="null"/>, <see cref="LearningRateMultiplier"/> will be provided.
        /// </remarks>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? LearningRate = null;

        /// <summary>
        /// The learning rate multiplier is used to calculate a final learningRate based on the default (recommended) value.
        /// </summary>
        /// <remarks>
        /// Actual learning rate := learningRateMultiplier * default learning rate Default learning rate is dependent on base model and dataset size. If not set, a default of 1.0 will be used.
        /// <br/><br/>
        /// If <see langword="null"/>, <see cref="LearningRate"/> will be provided.
        /// </remarks>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? LearningRateMultiplier = null;

        /// <summary>
        /// The number of training epochs. An epoch is one pass through the training data. If not set, a default of 5 will be used.
        /// </summary>
        public int EpochCount;

        /// <summary>
        /// The batch size hyperparameter for tuning. If not set, a default of 4 or 16 will be used based on the number of training examples.
        /// </summary>
        public int BatchSize;
    }
}
