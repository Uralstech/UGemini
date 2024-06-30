using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Chat
{
    /// <summary>
    /// Metadata on the generation request's token usage.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiUsageMetadata
    {
        /// <summary>
        /// Number of tokens in the prompt. When cachedContent is set, this is still the total effective prompt size. I.e. this includes the number of tokens in the cached content.
        /// </summary>
        /// <remarks>
        /// Cached content is not supported in this package.
        /// </remarks>
        public int PromptTokenCount;

        /// <summary>
        /// Total number of tokens across the generated candidates.
        /// </summary>
        public int CandidatesTokenCount;

        /// <summary>
        /// Total token count for the generation request (prompt + candidates).
        /// </summary>
        public int TotalTokenCount;
    }
}