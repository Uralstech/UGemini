using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Dataset for training or validation.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTuningDataset
    {
        /// <summary>
        /// Inline examples.
        /// </summary>
        public GeminiTuningExamples Examples;
    }
}
