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

namespace Uralstech.UGemini.Models.Generation.Candidate
{
    /// <summary>
    /// Metadata on the generation request's token usage.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiUsageMetadata : IAppendableData<GeminiUsageMetadata>
    {
        /// <summary>
        /// Number of tokens in the prompt. When cachedContent is set, this is still the total effective prompt size. I.e. this includes the number of tokens in the cached content.
        /// </summary>
        /// <remarks>
        /// Cached content is not supported in this package.
        /// </remarks>
        public int PromptTokenCount;

        /// <summary>
        /// Number of tokens in the cached part of the prompt, i.e. in the cached content.
        /// </summary>
        public int CachedContentTokenCount;

        /// <summary>
        /// Total number of tokens across the generated candidates.
        /// </summary>
        public int CandidatesTokenCount;

        /// <summary>
        /// Number of tokens present in tool-use prompt(s).
        /// </summary>
        public int ToolUsePromptTokenCount;

        /// <summary>
        /// Number of tokens of thoughts for thinking models.
        /// </summary>
        public int ThoughtsTokenCount;

        /// <summary>
        /// Total token count for the generation request (prompt + candidates).
        /// </summary>
        public int TotalTokenCount;

        /// <summary>
        /// List of modalities that were processed in the request input.
        /// </summary>
        public GeminiModalityTokenCount[] PromptTokensDetails;

        /// <summary>
        /// List of modalities of the cached content in the request input.
        /// </summary>
        public GeminiModalityTokenCount[] CacheTokensDetails;

        /// <summary>
        /// List of modalities that were returned in the response.
        /// </summary>
        public GeminiModalityTokenCount[] CandidatesTokensDetails;

        /// <summary>
        /// List of modalities that were processed for tool-use request inputs.
        /// </summary>
        public GeminiModalityTokenCount[] ToolUsePromptTokensDetails;

        /// <inheritdoc/>
        public void Append(GeminiUsageMetadata data)
        {
            PromptTokenCount = data.PromptTokenCount;
            CachedContentTokenCount = data.CachedContentTokenCount;
            CandidatesTokenCount = data.CandidatesTokenCount;
            ToolUsePromptTokenCount = data.ToolUsePromptTokenCount;
            ThoughtsTokenCount = data.ThoughtsTokenCount;
            TotalTokenCount = data.TotalTokenCount;

            PromptTokensDetails = data.PromptTokensDetails;
            CacheTokensDetails = data.CacheTokensDetails;
            CandidatesTokensDetails = data.CandidatesTokensDetails;
            ToolUsePromptTokensDetails = data.ToolUsePromptTokensDetails;
        }
    }
}