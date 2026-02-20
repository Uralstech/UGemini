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

namespace Uralstech.UGemini.Models.Generation.Candidate.GroundingMetadata
{
    /// <summary>
    /// Metadata returned to client when grounding is enabled.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingMetadata
    {
        /// <summary>
        /// List of supporting references retrieved from specified grounding source.
        /// </summary>
        public GeminiGroundingChunk[] GroundingChunks;

        /// <summary>
        /// List of grounding support.
        /// </summary>
        public GeminiGroundingSupport[] GroundingSupports;

        /// <summary>
        /// Web search queries for the following-up web search.
        /// </summary>
        public string[] WebSearchQueries;

        /// <summary>
        /// Google search entry for the following-up web searches.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiSearchEntryPoint SearchEntryPoint = null;

        /// <summary>
        /// Metadata related to retrieval in the grounding flow.
        /// </summary>
        public GeminiRetrievalMetadata RetrievalMetadata;
    }
}
