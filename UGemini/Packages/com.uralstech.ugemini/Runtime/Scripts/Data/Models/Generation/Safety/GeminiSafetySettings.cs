using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Safety
{
    /// <summary>
    /// Safety setting, affecting the safety-blocking behavior.
    /// </summary>
    /// <remarks>
    /// Passing a safety setting for a category changes the allowed probability that content is blocked.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSafetySettings
    {
        /// <summary>
        /// The category for this setting.
        /// </summary>
        public GeminiSafetyHarmCategory Category;

        /// <summary>
        /// Controls the probability threshold at which harm is blocked.
        /// </summary>
        public GeminiSafetyHarmBlockThreshold Threshold;
    }
}