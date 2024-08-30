using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Metadata on the usage of the cached content.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCachedContentUsageMetadata
    {
        /// <summary>
        /// Total number of tokens that the cached content consumes.
        /// </summary>
        public int TotalTokenCount;
    }
}