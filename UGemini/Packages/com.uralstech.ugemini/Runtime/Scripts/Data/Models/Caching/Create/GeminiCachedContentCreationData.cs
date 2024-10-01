using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel;
using Uralstech.UGemini.JsonConverters;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Tools.Declaration;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Data to cache content that has been preprocessed and can be used in subsequent request to GenerativeService.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCachedContentCreationData
    {
        /// <summary>
        /// The content to cache.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiContent[] Contents = null;

        /// <summary>
        /// A list of Tools the model may use to generate the next response.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiTool[] Tools = null;

        /// <summary>
        /// Timestamp in UTC of when this resource is considered expired.
        /// </summary>
        /// <remarks>
        /// If not provided, <see cref="TimeToLive"/> must be provided.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public DateTime? ExpireTime = null;

        /// <summary>
        /// New TTL for this resource.
        /// </summary>
        /// <remarks>
        /// If not provided, <see cref="ExpireTime"/> must be provided.
        /// </remarks>
        [JsonProperty("ttl", DefaultValueHandling = DefaultValueHandling.Ignore), JsonConverter(typeof(GeminiSecondsToTimeSpanJsonConverter)), DefaultValue(null)]
        public TimeSpan? TimeToLive = null;

        /// <summary>
        /// The user-generated meaningful display name of the cached content. Maximum 128 Unicode characters.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;

        /// <summary>
        /// The name of the Model to use for cached content.
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdStringConverter))]
        public GeminiModelId Model;

        /// <summary>
        /// Developer set system instruction. Currently text only.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiContent SystemInstruction = null;

        /// <summary>
        /// This config is shared for all tools.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiToolConfiguration ToolConfig = null;
    }
}