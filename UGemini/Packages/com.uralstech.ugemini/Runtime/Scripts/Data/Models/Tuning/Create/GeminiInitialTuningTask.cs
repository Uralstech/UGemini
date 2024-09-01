using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Tuning task that creates the tuned model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiInitialTuningTask
    {
        /// <summary>
        /// The model training data.
        /// </summary>
        public GeminiTuningDataset TrainingData;

        /// <summary>
        ///  Hyperparameters controlling the tuning process.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiTuningHyperparameters Hyperparameters = null;
    }
}
