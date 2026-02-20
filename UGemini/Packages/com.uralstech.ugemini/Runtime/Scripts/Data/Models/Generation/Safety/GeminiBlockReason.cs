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
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UGemini.Models.Generation.Safety
{
    /// <summary>
    /// Specifies what was the reason why prompt was blocked.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiBlockReason
    {
        /// <summary>
        /// Default value. This value is unused.
        /// </summary>
        [EnumMember(Value = "BLOCK_REASON_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Prompt was blocked due to safety reasons. You can inspect <see cref="Candidate.GeminiPromptFeedback.SafetyRatings"/> to understand which safety category blocked it.
        /// </summary>
        [EnumMember(Value = "SAFETY")]
        Safety,

        /// <summary>
        /// Prompt was blocked due to unknown reasons.
        /// </summary>
        [EnumMember(Value = "OTHER")]
        Other,

        /// <summary>
        /// Prompt was blocked due to the terms which are included from the terminology blocklist.
        /// </summary>
        [EnumMember(Value = "BLOCKLIST")]
        BlockList,

        /// <summary>
        /// Prompt was blocked due to prohibited content.
        /// </summary>
        [EnumMember(Value = "PROHIBITED_CONTENT")]
        ProhibitedContent,

        /// <summary>
        /// Candidates blocked due to unsafe image generation content.
        /// </summary>
        [EnumMember(Value = "IMAGE_SAFETY")]
        ImageSafety,
    }
}