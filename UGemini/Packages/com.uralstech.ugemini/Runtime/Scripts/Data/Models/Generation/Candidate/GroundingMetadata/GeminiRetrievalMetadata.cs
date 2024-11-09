using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Metadata related to retrieval in the grounding flow.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GeminiRetrievalMetadata
    {
        /// <summary>
        /// Score indicating how likely information from google search could help answer the prompt.
        /// </summary>
        /// <remarks>
        /// The score is in the range [0, 1], where 0 is the least likely and 1 is the most likely. This score is only populated when google search<br/>
        /// grounding and dynamic retrieval is enabled. It will be compared to the threshold to determine whether to trigger google search.
        /// </remarks>
        public float? GoogleSearchDynamicRetrievalScore = null;
    }
}
