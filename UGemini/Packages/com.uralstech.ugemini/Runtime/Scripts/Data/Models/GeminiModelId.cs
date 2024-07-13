using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models
{
    /// <summary>
    /// Information about the unique ID of a Generative Language Model.
    /// </summary>
    public class GeminiModelId
    {
        /// <summary>
        /// The resource name of the Model.
        /// </summary>
        /// <remarks>
        /// Format: models/{model} with a {model} naming convention of:<br/>
        /// "{baseModelId}-{version}"
        /// </remarks>
        [JsonProperty(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public string Name;

        /// <summary>
        /// The ID of the base model, pass this to the generation request.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public string BaseModelId;

        /// <summary>
        /// Creates a new <see cref="GeminiModelId"/>.
        /// </summary>
        /// <param name="baseModelId">The unique ID of the base model.</param>
        /// <param name="resourceLocation">The location of the model resource.</param>
        public GeminiModelId(string baseModelId, string resourceLocation = "models/")
        {
            BaseModelId = baseModelId;
            Name = $"{resourceLocation}{baseModelId}";
        }

        /// <summary>
        /// Gets the base model ID of the <see cref="GeminiModelId"/>.
        /// </summary>
        public static implicit operator string(GeminiModelId model)
        {
            return model?.BaseModelId;
        }

        /// <summary>
        /// Creates a new <see cref="GeminiModelId"/> with the base model ID string.
        /// </summary>
        public static implicit operator GeminiModelId(string baseModelId)
        {
            return new GeminiModelId(baseModelId);
        }
    }
}
