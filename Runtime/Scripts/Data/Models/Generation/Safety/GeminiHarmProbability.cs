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
    /// The probability that a piece of content is harmful.
    /// </summary>
    /// <remarks>
    /// The classification system gives the probability of the content being unsafe. This does not indicate the severity of harm for a piece of content.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiHarmProbability
    {
        /// <summary>
        /// Probability is unspecified.
        /// </summary>
        [EnumMember(Value = "HARM_PROBABILITY_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Content has a negligible chance of being unsafe.
        /// </summary>
        [EnumMember(Value = "NEGLIGIBLE")]
        Negligible,

        /// <summary>
        /// Content has a low chance of being unsafe.
        /// </summary>
        [EnumMember(Value = "LOW")]
        Low,

        /// <summary>
        /// Content has a medium chance of being unsafe.
        /// </summary>
        [EnumMember(Value = "MEDIUM")]
        Medium,

        /// <summary>
        /// Content has a high chance of being unsafe.
        /// </summary>
        [EnumMember(Value = "HIGH")]
        High,
    }
}