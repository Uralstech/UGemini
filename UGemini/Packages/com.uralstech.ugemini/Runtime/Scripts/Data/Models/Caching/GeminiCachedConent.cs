using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel;
using Uralstech.UGemini.Models.Content;
using Uralstech.UGemini.Models.Generation.Tools.Declaration;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Content that has been preprocessed and can be used in subsequent request to GenerativeService.
    /// </summary>
    /// <remarks>
    /// Cached content can be only used with model it was created for.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCachedContent
    {
        /// <summary>
        /// Immutable. The content to cache.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiContent[] Contents = null;

        /// <summary>
        /// Immutable. A list of Tools the model may use to generate the next response
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiTool[] Tools = null;

        /// <summary>
        /// Creation time of the cache entry.
        /// </summary>
        public DateTime CreateTime;

        /// <summary>
        /// When the cache entry was last updated in UTC time.
        /// </summary>
        public DateTime UpdateTime;

        /// <summary>
        /// Metadata on the usage of the cached content.
        /// </summary>
        public GeminiCachedContentUsageMetadata UsageMetadata;

        /// <summary>
        /// Timestamp in UTC of when this resource is considered expired. This is always provided on output, regardless of what was sent on input.
        /// </summary>
        public DateTime ExpireTime;

        /// <summary>
        /// Input only. New TTL for this resource, input only.
        /// </summary>
        [JsonProperty("ttl"), JsonConverter(typeof(GeminiSecondsToTimeSpanJsonConverter))]
        public DateTime TimeToLive;

        /// <summary>
        /// Optional. Identifier. The resource name referring to the cached content. Format: cachedContents/{id}
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string Name = null;

        /// <summary>
        /// Optional. Immutable. The user-generated meaningful display name of the cached content. Maximum 128 Unicode characters.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;

        /// <summary>
        /// Immutable. The name of the Model to use for cached content Format: mod
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdStringConverter))]
        public GeminiModelId Model;

        /// <summary>
        /// Immutable. Developer set system instruction. Currently text only.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiContent SystemInstruction = null;

        /// <summary>
        /// Immutable. Tool config. This config is shared for all tools.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiToolConfiguration ToolConfig = null;
    }
}