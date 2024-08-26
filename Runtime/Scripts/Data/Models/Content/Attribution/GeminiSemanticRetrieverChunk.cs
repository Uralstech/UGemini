using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Content.Attribution
{
    /// <summary>
    /// Identifier for a Chunk retrieved via Semantic Retriever specified in the GenerateAnswerRequest using SemanticRetrieverConfig.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSemanticRetrieverChunk
    {
        /// <summary>
        /// Name of the source matching the request's SemanticRetrieverConfig.source. Example: corpora/123 or corpora/123/documents/abc
        /// </summary>
        public string Source;

        /// <summary>
        /// Name of the Chunk containing the attributed text. Example: corpora/123/documents/abc/chunks/xyz
        /// </summary>
        public string Chunk;
    }
}