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
    /// Block at and beyond a specified harm probability.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiSafetyHarmBlockThreshold
    {
        /// <summary>
        /// Threshold is unspecified.
        /// </summary>
        [EnumMember(Value = "HARM_BLOCK_THRESHOLD_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Content with <see cref="GeminiHarmProbability.Negligible"/> will be allowed.
        /// </summary>
        [EnumMember(Value = "BLOCK_LOW_AND_ABOVE")]
        LowAndAbove,

        /// <summary>
        /// Content with <see cref="GeminiHarmProbability.Negligible"/> and <see cref="GeminiHarmProbability.Low"/> will be allowed.
        /// </summary>
        [EnumMember(Value = "BLOCK_MEDIUM_AND_ABOVE")]
        MediumAndAbove,

        /// <summary>
        /// Content with <see cref="GeminiHarmProbability.Negligible"/>, <see cref="GeminiHarmProbability.Low"/>, and <see cref="GeminiHarmProbability.Medium"/> will be allowed.
        /// </summary>
        [EnumMember(Value = "BLOCK_ONLY_HIGH")]
        OnlyHigh,

        /// <summary>
        /// All content will be allowed.
        /// </summary>
        [EnumMember(Value = "BLOCK_NONE")]
        None,

        /// <summary>
        /// Turn off the safety filter.
        /// </summary>
        [EnumMember(Value = "OFF")]
        Off,
    }
}