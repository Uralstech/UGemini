using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Embedding
{
    /// <summary>
    /// The response to a <see cref="GeminiEmbedContentRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiEmbedContentResponse
    {
        /// <summary>
        /// The embedding generated from the input content.
        /// </summary>
        public GeminiContentEmbedding Embedding;
    }
}
