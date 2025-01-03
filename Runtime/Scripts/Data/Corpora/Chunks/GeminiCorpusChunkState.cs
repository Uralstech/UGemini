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

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// States for the lifecycle of a Chunk.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeminiCorpusChunkState
    {
        /// <summary>
        /// The default value. This value is used if the state is omitted.
        /// </summary>
        [EnumMember(Value = "STATE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Chunk is being processed (embedding and vector storage).
        /// </summary>
        [EnumMember(Value = "STATE_PENDING_PROCESSING")]
        Processing,

        /// <summary>
        /// Chunk is processed and available for querying.
        /// </summary>
        [EnumMember(Value = "STATE_ACTIVE")]
        Active,

        /// <summary>
        /// Chunk failed processing.
        /// </summary>
        [EnumMember(Value = "STATE_FAILED")]
        Failed,
    }
}
