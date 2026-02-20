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
using System.ComponentModel;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// User provided metadata stored as key-value pairs.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpusCustomMetadata
    {
        /// <summary>
        /// The key of the metadata to store.
        /// </summary>
        public string Key;

        /// <summary>
        /// The string value of the metadata to store.
        /// </summary>
        /// <remarks>
        /// Only one of <see cref="StringValue"/>, <see cref="StringListValue"/><br/>
        /// or <see cref="NumericValue"/> must be provided at a time.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string StringValue = null;

        /// <summary>
        /// The StringList value of the metadata to store.
        /// </summary>
        /// <remarks>
        /// Only one of <see cref="StringValue"/>, <see cref="StringListValue"/><br/>
        /// or <see cref="NumericValue"/> must be provided at a time.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusCustomMetadataStringList StringListValue = null;

        /// <summary>
        /// The numeric value of the metadata to store.
        /// </summary>
        /// <remarks>
        /// Only one of <see cref="StringValue"/>, <see cref="StringListValue"/><br/>
        /// or <see cref="NumericValue"/> must be provided at a time.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public float? NumericValue = null;
    }
}