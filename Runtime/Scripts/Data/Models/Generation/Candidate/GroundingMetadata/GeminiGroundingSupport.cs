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
    /// Grounding support.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiGroundingSupport
    {
        /// <summary>
        /// A list of indices (into <see cref="GeminiGroundingMetadata.GroundingChunks"/>) specifying the citations associated with the claim.
        /// </summary>
        /// <remarks>
        /// For instance [1,3,4] means that <see cref="GeminiGroundingMetadata.GroundingChunks"/>[1], <see cref="GeminiGroundingMetadata.GroundingChunks"/>[3],<br/>
        /// <see cref="GeminiGroundingMetadata.GroundingChunks"/>[4] are the retrieved content attributed to the claim.
        /// </remarks>
        public int[] GroundingChunkIndices;

        /// <summary>
        /// Confidence score of the support references.
        /// </summary>
        /// <remarks>
        /// Ranges from 0 to 1. 1 is the most confident. This list must have the same size as the <see cref="GroundingChunkIndices"/>.
        /// </remarks>
        public float[] ConfidenceScores;

        /// <summary>
        /// Segment of the content this support belongs to.
        /// </summary>
        public GeminiGroundingSupportSegment Segment;
    }
}
