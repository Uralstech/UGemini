using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// A single example for tuning.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTuningExample
    {
        /// <summary>
        /// The expected model output.
        /// </summary>
        public string Output;

        /// <summary>
        /// Text model input.
        /// </summary>
        public string TextInput;
    }
}
