using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel;
using Uralstech.UGemini.JsonConverters;

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
        /// Timestamp in UTC of when this resource is considered expired.
        /// </summary>
        public DateTime ExpireTime;

        /// <summary>
        /// The resource name referring to the cached content. Format: cachedContents/{contentId}.
        /// </summary>
        public string Name = null;

        /// <summary>
        /// The user-generated meaningful display name of the cached content. Maximum 128 Unicode characters.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;

        /// <summary>
        /// The name of the Model to use for cached content Format: mod
        /// </summary>
        [JsonConverter(typeof(GeminiModelIdStringConverter))]
        public GeminiModelId Model;
    }
}