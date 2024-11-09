using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Segment of the content.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingSupportSegment
    {
        /// <summary>
        /// The index of a <see cref="Content.GeminiContentPart"/> object within its parent <see cref="Content.GeminiContent"/> object.
        /// </summary>
        public int PartIndex;

        /// <summary>
        /// Start index in the given <see cref="Content.GeminiContentPart"/>, measured in bytes. Offset from the start of the <see cref="Content.GeminiContentPart"/>, inclusive, starting at zero.
        /// </summary>
        public int StartIndex;

        /// <summary>
        /// End index in the given <see cref="Content.GeminiContentPart"/>, measured in bytes. Offset from the start of the <see cref="Content.GeminiContentPart"/>, exclusive, starting at zero.
        /// </summary>
        public int EndIndex;

        /// <summary>
        /// The text corresponding to the segment from the response.
        /// </summary>
        public string Text;
    }
}
