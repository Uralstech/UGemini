using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.Models.Tuning
{
    /// <summary>
    /// Tuned model as a source for training a new model.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTunedModelSource
    {
        /// <summary>
        /// The name of the <see cref="GeminiTunedModel"/> to use as the starting point for training the new model. Example: tunedModels/my-tuned-model
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdStringConverter))]
        public GeminiModelId TunedModel;

        /// <summary>
        /// The name of the base <see cref="GeminiModel"/> this <see cref="GeminiTunedModel"/> was tuned from. Example: models/gemini-1.5-flash-001
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdStringConverter))]
        public GeminiModelId BaseModel;
    }
}
