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
using Uralstech.UGemini.Models.Generation.Safety;

namespace Uralstech.UGemini.Models.Generation.Candidate
{
    /// <summary>
    /// A set of the feedback metadata for the prompt specified in a generation request.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiPromptFeedback : IAppendableData<GeminiPromptFeedback>
    {
        /// <summary>
        /// If set, the prompt was blocked and no candidates are returned. Rephrase your prompt.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiBlockReason BlockReason;

        /// <summary>
        /// Ratings for safety of the prompt. There is at most one rating per category.
        /// </summary>
        public GeminiSafetyRating[] SafetyRatings;

        /// <inheritdoc/>
        public void Append(GeminiPromptFeedback data)
        {
            if (data.BlockReason != default)
                BlockReason = data.BlockReason;

            SafetyRatings = data.SafetyRatings;
        }
    }
}