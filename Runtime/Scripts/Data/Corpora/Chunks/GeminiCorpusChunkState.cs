using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// States for the lifecycle of a Chunk.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiCorpusChunkState
    {
        /// <summary>
        /// The default value. This value is used if the state is omitted.
        /// </summary>
        [EnumMember(Value = "STATE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Chunk is being processed (embedding and vector storage).
        /// </summary>
        [EnumMember(Value = "STATE_PENDING_PROCESSING")]
        Processing,

        /// <summary>
        /// Chunk is processed and available for querying.
        /// </summary>
        [EnumMember(Value = "STATE_ACTIVE")]
        Active,

        /// <summary>
        /// Chunk failed processing.
        /// </summary>
        [EnumMember(Value = "STATE_FAILED")]
        Failed,
    }
}
