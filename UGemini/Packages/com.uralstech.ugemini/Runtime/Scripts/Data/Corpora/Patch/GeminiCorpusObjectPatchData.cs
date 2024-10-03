using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Data to patch an existing Document or Chunk resource with new data.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpusObjectPatchData : GeminiCorpusPatchData
    {
        /// <summary>
        /// User provided custom metadata stored as key-value pairs used for querying. A Document or Chunk can have a maximum of 20 CustomMetadata.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusCustomMetadata[] CustomMetadata = null;
    }
}