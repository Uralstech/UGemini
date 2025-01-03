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
using System.ComponentModel;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Information to create a new Chunk as part of a <see cref="GeminiCorporaChunkBatchCreateRequest"/>.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchCreationData
    {
        /// <summary>
        /// The Chunk's resource ID.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/*/documents/*/chunks/" prefix) can contain up to 40 characters that are lowercase<br/>
        /// alphanumeric or dashes (-). The ID cannot start or end with a dash. If the name is empty on create, a unique name will<br/>
        /// be derived from 12 random characters.
        /// </remarks>
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore), JsonConverter(typeof(GeminiCorpusResourceIdToStringConverter)), DefaultValue(null)]
        public IGeminiCorpusResourceId ChunkId = null;

        /// <summary>
        /// The content for the Chunk, such as text. The maximum number of tokens per chunk is 2043.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusChunkData Data = null;

        /// <summary>
        /// User provided custom metadata stored as key-value pairs used for querying. A Chunk can have a maximum of 20 CustomMetadata.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusCustomMetadata[] CustomMetadata = null;
    }
}
