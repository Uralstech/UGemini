using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// A set of tuning examples. Can be training or validation data.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTuningExamples
    {
        /// <summary>
        /// The examples. Example input can be for text or discuss, but all examples in a set must be of the same type.
        /// </summary>
        public GeminiTuningExample[] Examples;
    }
}
