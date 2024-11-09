using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Tools.Declaration.GoogleSearch
{
    /// <summary>
    /// Tool to retrieve public web data for grounding, powered by Google.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGoogleSearchRetrieval
    {
        /// <summary>
        /// Specifies the dynamic retrieval configuration for the given source.
        /// </summary>
        public GeminiDynamicRetrievalConfig DynamicRetrievalConfig;
    }
}