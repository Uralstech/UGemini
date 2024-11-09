using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Grounding chunk.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingChunk
    {
        /// <summary>
        /// Grounding chunk from the web.
        /// </summary>
        public GeminiWebGroundingChunk Web;
    }
}
