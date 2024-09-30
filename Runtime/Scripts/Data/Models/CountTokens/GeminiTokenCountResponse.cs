using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.CountTokens
{
    /// <summary>
    /// A response from CountTokens.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTokenCountResponse
    {
        /// <summary>
        /// The number of tokens that the model tokenizes the prompt into.
        /// </summary>
        /// <remarks>
        /// Always non-negative. When cachedContent is set, this is still the total effective prompt size.I.e.this includes the number of tokens in the cached content.
        /// <br/><br/>
        /// Cached content is not supported in this package.
        /// </remarks>
        public int TotalTokens;

        /// <summary>
        /// Number of tokens in the cached part of the prompt (the cached content).
        /// </summary>
        public int CachedContentTokenCount;
    }
}