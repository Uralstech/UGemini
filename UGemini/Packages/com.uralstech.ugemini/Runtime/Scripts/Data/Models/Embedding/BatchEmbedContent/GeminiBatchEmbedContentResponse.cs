using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Embedding
{
    /// <summary>
    /// The response to a <see cref="GeminiBatchEmbedContentRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiBatchEmbedContentResponse
    {
        /// <summary>
        /// The embeddings for each request, in the same order as provided in the batch request.
        /// </summary>
        public GeminiContentEmbedding[] Embeddings;
    }
}
