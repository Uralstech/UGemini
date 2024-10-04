using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Information to create a new Chunk as part of a <see cref="GeminiCorporaChunkBatchCreateRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchCreationData
    {
        /// <summary>
        /// The Chunk's resource ID.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/*/documents/*/chunks/" prefix) can contain up to 40 characters that are lowercase<br/>
        /// alphanumeric or dashes (-). The ID cannot start or end with a dash. If the name is empty on create, a unique name will<br/>
        /// be derived from 12 random characters.
        /// </remarks>
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore), JsonConverter(typeof(GeminiCorpusResourceIdToStringConverter)), DefaultValue(null)]
        public IGeminiCorpusResourceId ChunkId = null;

        /// <summary>
        /// The content for the Chunk, such as text. The maximum number of tokens per chunk is 2043.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusChunkData Data = null;

        /// <summary>
        /// User provided custom metadata stored as key-value pairs used for querying. A Chunk can have a maximum of 20 CustomMetadata.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusCustomMetadata[] CustomMetadata = null;
    }
}
