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

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Request to update a Chunk. Part of multiple requests in a <see cref="GeminiCorporaChunkBatchUpdateRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchUpdateRequestPart
    {
        /// <summary>
        /// The patch data for the Chunk.
        /// </summary>
        public GeminiCorpusChunkPatchData Chunk;

        /// <summary>
        /// The list of fields to update. This is automatically generated.
        /// </summary>
        public string UpdateMask;

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaChunkBatchUpdateRequestPart"/>.
        /// </summary>
        /// <param name="chunk">The patch data for the Chunk.</param>
        public GeminiCorporaChunkBatchUpdateRequestPart(GeminiCorpusChunkPatchData chunk)
        {
            Chunk = chunk;
            UpdateMask = Chunk.GetFieldMask();
        }
    }
}
