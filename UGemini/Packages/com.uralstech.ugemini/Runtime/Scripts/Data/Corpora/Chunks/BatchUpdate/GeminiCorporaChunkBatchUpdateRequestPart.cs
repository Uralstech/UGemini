using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Request to update a Chunk. Part of multiple requests in a <see cref="GeminiCorporaChunkBatchUpdateRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchUpdateRequestPart
    {
        /// <summary>
        /// The patch data for the Chunk.
        /// </summary>
        public GeminiCorpusChunkPatchData Chunk;

        /// <summary>
        /// The list of fields to update. This is automatically generated.
        /// </summary>
        public string UpdateMask;

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaChunkBatchUpdateRequestPart"/>.
        /// </summary>
        /// <param name="chunk">The patch data for the Chunk.</param>
        public GeminiCorporaChunkBatchUpdateRequestPart(GeminiCorpusChunkPatchData chunk)
        {
            Chunk = chunk;
            UpdateMask = Chunk.GetFieldMask();
        }
    }
}
