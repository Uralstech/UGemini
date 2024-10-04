using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// User provided string values assigned to a single metadata key.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpusCustomMetadataStringList
    {
        /// <summary>
        /// The string values of the metadata to store.
        /// </summary>
        public string[] Values;
    }
}