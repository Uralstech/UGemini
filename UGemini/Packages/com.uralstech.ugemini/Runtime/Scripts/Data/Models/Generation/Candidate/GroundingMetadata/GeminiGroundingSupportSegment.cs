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
    /// Segment of the content.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingSupportSegment
    {
        /// <summary>
        /// The index of a <see cref="Content.GeminiContentPart"/> object within its parent <see cref="Content.GeminiContent"/> object.
        /// </summary>
        public int PartIndex;

        /// <summary>
        /// Start index in the given <see cref="Content.GeminiContentPart"/>, measured in bytes. Offset from the start of the <see cref="Content.GeminiContentPart"/>, inclusive, starting at zero.
        /// </summary>
        public int StartIndex;

        /// <summary>
        /// End index in the given <see cref="Content.GeminiContentPart"/>, measured in bytes. Offset from the start of the <see cref="Content.GeminiContentPart"/>, exclusive, starting at zero.
        /// </summary>
        public int EndIndex;

        /// <summary>
        /// The text corresponding to the segment from the response.
        /// </summary>
        public string Text;
    }
}
