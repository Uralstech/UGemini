using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.Models.Caching
{
    /// <summary>
    /// Data to patch an existing cached content resource with new data.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCachedContentPatchData
    {
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
    }
}