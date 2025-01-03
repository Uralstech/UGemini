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
using Uralstech.UGemini.CorporaAPI.Filters;
using Uralstech.UGemini.Models.Content;

namespace Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever
{
    /// <summary>
    /// Configuration for retrieving grounding content from a Corpus or Document created using the Semantic Retriever API.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiSemanticRetrieverConfig
    {
        /// <summary>
        /// Name of the resource for retrieval, e.g. corpora/123 or corpora/123/documents/abc.
        /// </summary>
        public string Source;

        /// <summary>
        /// Query to use for similarity matching Chunks in the given resource.
        /// </summary>
        public GeminiContent Query;

        /// <summary>
        /// Filters for selecting Documents and/or Chunks from the resource.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiMetadataFilter[] MetadataFilters = null;

        /// <summary>
        /// Maximum number of relevant Chunks to retrieve.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1)]
        public int MaxChunksCount = -1;

        /// <summary>
        /// Minimum relevance score for retrieved relevant Chunks.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1f)]
        public float MinimumRelevanceScore = -1f;
    }
}
