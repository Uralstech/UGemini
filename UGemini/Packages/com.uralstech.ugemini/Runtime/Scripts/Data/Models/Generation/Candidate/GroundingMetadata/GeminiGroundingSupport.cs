using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Grounding support.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingSupport
    {
        /// <summary>
        /// A list of indices (into <see cref="GeminiGroundingMetadata.GroundingChunks"/>) specifying the citations associated with the claim.
        /// </summary>
        /// <remarks>
        /// For instance [1,3,4] means that <see cref="GeminiGroundingMetadata.GroundingChunks"/>[1], <see cref="GeminiGroundingMetadata.GroundingChunks"/>[3],<br/>
        /// <see cref="GeminiGroundingMetadata.GroundingChunks"/>[4] are the retrieved content attributed to the claim.
        /// </remarks>
        public int[] GroundingChunkIndices;

        /// <summary>
        /// Confidence score of the support references.
        /// </summary>
        /// <remarks>
        /// Ranges from 0 to 1. 1 is the most confident. This list must have the same size as the <see cref="GroundingChunkIndices"/>.
        /// </remarks>
        public float[] ConfidenceScores;

        /// <summary>
        /// Segment of the content this support belongs to.
        /// </summary>
        public GeminiGroundingSupportSegment Segment;
    }
}
