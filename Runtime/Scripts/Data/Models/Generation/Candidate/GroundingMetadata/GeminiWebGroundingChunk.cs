using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Chunk from the web.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiWebGroundingChunk
    {
        /// <summary>
        /// URI reference of the chunk.
        /// </summary>
        public string Uri;

        /// <summary>
        /// Title of the chunk.
        /// </summary>
        public string Title;
    }
}
