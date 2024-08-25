using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Chat
{
    /// <summary>
    /// A collection of source attributions for a piece of content.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCitationMetadata
    {
        /// <summary>
        /// Citations to sources for a specific response.
        /// </summary>
        public GeminiCitationSource[] CitationSources;
    }
}