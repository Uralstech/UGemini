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
using Uralstech.UGemini.Models.Generation.Candidate;

namespace Uralstech.UGemini.Models.CountTokens
{
    /// <summary>
    /// A response from CountTokens.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiTokenCountResponse
    {
        /// <summary>
        /// The number of tokens that the model tokenizes the prompt into.
        /// </summary>
        /// <remarks>
        /// Always non-negative. When cachedContent is set, this is still the total effective prompt size.I.e.this includes the number of tokens in the cached content.
        /// <br/><br/>
        /// Cached content is not supported in this package.
        /// </remarks>
        public int TotalTokens;

        /// <summary>
        /// Number of tokens in the cached part of the prompt (the cached content).
        /// </summary>
        public int CachedContentTokenCount;

        /// <summary>
        /// List of modalities that were processed in the request input.
        /// </summary>
        public GeminiModalityTokenCount[] PromptTokensDetails;
    }
}