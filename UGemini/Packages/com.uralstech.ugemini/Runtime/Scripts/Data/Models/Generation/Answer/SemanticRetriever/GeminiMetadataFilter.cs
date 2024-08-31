using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever
{
    /// <summary>
    /// User provided filter to limit retrieval based on Chunk or Document level metadata values.
    /// </summary>
    /// <remarks>
    /// Example (genre = drama OR genre = action): key = "document.custom_metadata.genre" conditions = [{stringValue = "drama", operation = EQUAL}, {stringValue = "action", operation = EQUAL}]
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiMetadataFilter
    {
        /// <summary>
        /// The key of the metadata to filter on.
        /// </summary>
        public string Key;

        /// <summary>
        /// The Conditions for the given key that will trigger this filter. Multiple Conditions are joined by logical ORs.
        /// </summary>
        public GeminiMetadataCondition[] Conditions;
    }
}
