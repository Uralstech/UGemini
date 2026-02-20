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

namespace Uralstech.UGemini.Models.Content.Attribution
{
    /// <summary>
    /// Identifier for a part within a GroundingPassage.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingPassageId
    {
        /// <summary>
        /// ID of the passage matching the GenerateAnswerRequest's <see cref="GeminiAttributionSourceId.GroundingPassage"/>.
        /// </summary>
        public string PassageId;

        /// <summary>
        /// Index of the part within the GenerateAnswerRequest's <see cref="GeminiAttributionSourceId.GroundingPassage"/>.
        /// </summary>
        public int PartIndex;
    }
}