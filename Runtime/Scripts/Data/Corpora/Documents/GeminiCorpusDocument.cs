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
using System;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.CorporaAPI.Documents
{
    /// <summary>
    /// A Document is a collection of Chunks. A Corpus can have a maximum of 10,000 Documents.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorpusDocument
    {
        /// <summary>
        /// The Document resource ID.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/*/documents/" prefix) can contain up to 40 characters that are lowercase alphanumeric<br/>
        /// or dashes (-). The ID cannot start or end with a dash. If the name is empty on create, a unique name will be derived from<br/>
        /// displayName along with a 12 character random suffix. Example: corpora/{corpus_id}/documents/my-awesome-doc-123a456b789c
        /// </remarks>
        [JsonProperty("name"), JsonConverter(typeof(GeminiCorpusResourceIdToStringConverter<GeminiCorpusDocumentId>))]
        public GeminiCorpusDocumentId Resource;

        /// <summary>
        /// The human-readable display name for the Document.
        /// </summary>
        /// <remarks>
        /// The display name must be no more than 512 characters in length, including spaces. Example: "Semantic Retriever Documentation"
        /// </remarks>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName = null;

        /// <summary>
        /// User provided custom metadata stored as key-value pairs used for querying. A Document can have a maximum of 20 CustomMetadata.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GeminiCorpusCustomMetadata[] CustomMetadata = null;

        /// <summary>
        /// The Timestamp of when the Document was created.
        /// </summary>
        public DateTime CreateTime;

        /// <summary>
        /// The Timestamp of when the Document was last updated.
        /// </summary>
        public DateTime UpdateTime;
    }
}
