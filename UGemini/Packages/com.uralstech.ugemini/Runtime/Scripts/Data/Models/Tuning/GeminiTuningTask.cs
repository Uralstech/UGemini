using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Tuning tasks that create tuned models.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTuningTask
    {
        /// <summary>
        /// The timestamp when tuning this model started.
        /// </summary>
        public DateTime StartTime;

        /// <summary>
        /// The timestamp when tuning this model completed.
        /// </summary>
        public DateTime CompleteTime;

        /// <summary>
        /// Metrics collected during tuning.
        /// </summary>
        public GeminiTuningSnapshot[] Snapshots;

        /// <summary>
        ///  Hyperparameters controlling the tuning process.
        /// </summary>
        public GeminiTuningHyperparameters Hyperparameters;
    }
}
