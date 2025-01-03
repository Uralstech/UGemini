// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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