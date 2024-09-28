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
        /// The default resource location for all models.
        /// </summary>
        public const string DefaultModelResourceLocation = "models/";

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
        /// The ID of the base model, not very useful for <see cref="Tuning.GeminiTunedModel"/>s.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public string BaseModelId;

        /// <summary>
        /// Creates a new <see cref="GeminiModelId"/>.
        /// </summary>
        /// <param name="nameOrBaseModelId">The full name of the model resource (see <see cref="Name"/>) or the unique ID of the base model.</param>
        public GeminiModelId(string nameOrBaseModelId)
        {
            if (string.IsNullOrEmpty(nameOrBaseModelId))
                return;

            int index = nameOrBaseModelId.IndexOf('/');
            if (index < 0)
            {
                BaseModelId = nameOrBaseModelId;
                Name = $"{DefaultModelResourceLocation}{nameOrBaseModelId}";
            }
            else
            {
                BaseModelId = nameOrBaseModelId[(index + 1)..];
                Name = nameOrBaseModelId;
            }
        }

        /// <summary>
        /// Creates a new <see cref="GeminiModelId"/>.
        /// </summary>
        /// <param name="name">The resource name of the Model, see <see cref="Name"/>.</param>
        /// <param name="baseModelId">The ID of the base model.</param>
        public GeminiModelId(string name, string baseModelId)
        {
            Name = name;
            BaseModelId = baseModelId;
        }

        /// <summary>
        /// Gets the full name of the model resource of the <see cref="GeminiModelId"/>.
        /// </summary>
        /// <param name="model">The <see cref="GeminiModelId"/>.</param>
        public static implicit operator string(GeminiModelId model)
        {
            return model?.Name;
        }

        /// <summary>
        /// Creates a new <see cref="GeminiModelId"/> with the full name of the model resource (see <see cref="Name"/>) or the unique ID of the base model.
        /// </summary>
        /// <param name="nameOrBaseModelId">The full name of the model resource or the unique ID of the base model.</param>
        public static implicit operator GeminiModelId(string nameOrBaseModelId)
        {
            return new GeminiModelId(nameOrBaseModelId);
        }
    }
}
