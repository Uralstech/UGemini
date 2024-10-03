using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// A Chunk is a subpart of a Document that is treated as an independent unit for the purposes of vector<br/>
    /// representation and storage. A Corpus can have a maximum of 1 million Chunks.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpusChunk
    {
        /// <summary>
        /// The Chunk resource ID.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/*/documents/*/chunks/" prefix) can contain up to 40 characters<br/>
        /// that are lowercase alphanumeric or dashes (-). The ID cannot start or end with a dash. If the name<br/>
        /// is empty on create, a random 12-character unique ID will be generated. Example:<br/>
        /// corpora/{corpus_id}/documents/{document_id}/chunks/123a456b789c
        /// </remarks>
        [JsonProperty("name"), JsonConverter(typeof(GeminiCorpusResourceIdToStringConverter<GeminiCorpusChunkId>))]
        public GeminiCorpusChunkId Resource;

        /// <summary>
        /// The content for the Chunk, such as the text string. The maximum number of tokens per chunk is 2043.
        /// </summary>
        public GeminiCorpusChunkData Data;

        /// <summary>
        /// User provided custom metadata stored as key-value pairs. The maximum number of CustomMetadata per chunk is 20.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiCorpusCustomMetadata[] CustomMetadata = null;

        /// <summary>
        /// The timestamp of when the Chunk was created.
        /// </summary>
        public DateTime CreateTime;

        /// <summary>
        /// The timestamp of when the Chunk was last updated.
        /// </summary>
        public DateTime UpdateTime;

        /// <summary>
        /// Current state of the Chunk.
        /// </summary>
        public GeminiCorpusChunkState State;
    }
}
