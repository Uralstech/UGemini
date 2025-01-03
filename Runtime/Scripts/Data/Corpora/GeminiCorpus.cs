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
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// A Corpus is a collection of Documents. A project can create up to 5 corpora.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpus
    {
        /// <summary>
        /// The Corpus resource.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/" prefix) can contain up to 40 characters that are lowercase alphanumeric or dashes (-).<br/>
        /// The ID cannot start or end with a dash. If the name is empty on create, a unique name will be derived from displayName along<br/>
        /// with a 12 character random suffix. Example: corpora/my-awesome-corpora-123a456b789c
        /// </remarks>
        [JsonProperty("name"), JsonConverter(typeof(GeminiCorpusResourceIdToStringConverter<GeminiCorpusId>))]
        public GeminiCorpusId Resource;

        /// <summary>
        /// The human-readable display name for the Corpus.
        /// </summary>
        /// <remarks>
        /// The display name must be no more than 512 characters in length, including spaces. Example: "Docs on Semantic Retriever"
        /// </remarks>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName = null;

        /// <summary>
        /// The timestamp of when the Corpus was created.
        /// </summary>
        public DateTime CreateTime;

        /// <summary>
        /// The timestamp of when the Corpus was last updated.
        /// </summary>
        public DateTime UpdateTime;
    }
}
