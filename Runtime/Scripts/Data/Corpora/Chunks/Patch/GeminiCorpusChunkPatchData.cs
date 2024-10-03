using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Data to patch an existing Chunk resource with new data.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpusChunkPatchData
    {
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