using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate
{
    /// <summary>
    /// Metadata on the generation request's token usage.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiUsageMetadata : IAppendableData<GeminiUsageMetadata>
    {
        /// <summary>
        /// Number of tokens in the prompt. When cachedContent is set, this is still the total effective prompt size. I.e. this includes the number of tokens in the cached content.
        /// </summary>
        /// <remarks>
        /// Cached content is not supported in this package.
        /// </remarks>
        public int PromptTokenCount;

        /// <summary>
        /// Number of tokens in the cached part of the prompt, i.e. in the cached content.
        /// </summary>
        public int CachedContentTokenCount;

        /// <summary>
        /// Total number of tokens across the generated candidates.
        /// </summary>
        public int CandidatesTokenCount;

        /// <summary>
        /// Total token count for the generation request (prompt + candidates).
        /// </summary>
        public int TotalTokenCount;

        /// <inheritdoc/>
        public void Append(GeminiUsageMetadata data)
        {
            PromptTokenCount = data.PromptTokenCount;
            CachedContentTokenCount = data.CachedContentTokenCount;
            CandidatesTokenCount = data.CandidatesTokenCount;
            TotalTokenCount = data.TotalTokenCount;
        }
    }
}