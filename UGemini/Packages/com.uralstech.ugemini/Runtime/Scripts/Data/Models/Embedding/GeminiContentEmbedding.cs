using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Embedding
{
    /// <summary>
    /// A list of floats representing an embedding.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiContentEmbedding
    {
        /// <summary>
        /// The embedding values.
        /// </summary>
        public float[] Values;
    }
}
