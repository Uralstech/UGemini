using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Record for a single tuning step.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTuningSnapshot
    {
        /// <summary>
        /// The tuning step.
        /// </summary>
        public int Step;

        /// <summary>
        /// The epoch this step was part of.
        /// </summary>
        public int Epoch;

        /// <summary>
        /// The mean loss of the training examples for this step.
        /// </summary>
        public float MeanLoss;

        /// <summary>
        /// The timestamp when this metric was computed.
        /// </summary>
        public DateTime ComputeTime;
    }
}
