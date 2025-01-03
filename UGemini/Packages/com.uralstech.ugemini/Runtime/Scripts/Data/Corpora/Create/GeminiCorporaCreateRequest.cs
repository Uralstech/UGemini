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
using Uralstech.UGemini.CorporaAPI.Chunks;
using Uralstech.UGemini.CorporaAPI.Documents;
using Uralstech.UGemini.JsonConverters;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Creates a new Corpora API resource. Response type can be <see cref="GeminiCorpus"/>,
    /// <see cref="GeminiCorpusDocument"/> or <see cref="GeminiCorpusChunk"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The resource's ID.
        /// </summary>
        /// <remarks>
        /// The ID (name excluding the "corpora/" or "corpora/*/documents/", "corpora/*/documents/*/chunks/" prefixes) can contain up to 40<br/>
        /// characters that are lowercase alphanumeric or dashes (-). The ID cannot start or end with a dash. If the name is empty on create,<br/>
        /// a unique name will be derived from <see cref="DisplayName"/> along with a 12 character random suffix. For<br/>
        /// Chunk creation requests, only the 12 character suffix will be generated.
        /// </remarks>
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore), JsonConverter(typeof(GeminiCorpusResourceIdToStringConverter)), DefaultValue(null)]
        public IGeminiCorpusResourceId ResourceId = null;

        /// <summary>
        /// The human-readable display name for the resource.
        /// </summary>
        /// <remarks>
        /// The display name must be no more than 512 characters in length, including spaces. Unsupported for Chunk creation requests.<br/>
        /// Example: "Docs on Semantic Retriever"
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public string DisplayName = null;

        /// <summary>
        /// The content for the Chunk, such as text. The maximum number of tokens per chunk is 2043.
        /// </summary>
        /// <remarks>
        /// Required for Chunk creation requests.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusChunkData Data = null;

        /// <summary>
        /// User provided custom metadata stored as key-value pairs used for querying. A Document/Chunk can have a maximum of 20 CustomMetadata.
        /// </summary>
        /// <remarks>
        /// Not supported for Corpus creation requests.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public GeminiCorpusCustomMetadata[] CustomMetadata = null;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <summary>
        /// The parent resource under which this resource will be created in.
        /// </summary>
        /// <remarks>
        /// Not supported for Corpus creation requests.
        /// </remarks>
        [JsonIgnore]
        public IGeminiCorpusResourceId ParentResourceId = null;

        /// <inheritdoc/>
        [JsonIgnore]
        public string ContentType => GeminiContentType.ApplicationJSON.MimeType();

        /// <inheritdoc/>
        [JsonIgnore]
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        [JsonIgnore]
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            string parentResource = ParentResourceId?.ResourceName ?? "corpora";
            string createMethod = ParentResourceId switch
            {
                GeminiCorpusDocumentId => "/chunks",
                GeminiCorpusId => "/documents",
                _ => string.Empty
            };

            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{parentResource}{createMethod}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaCreateRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="parentResourceId">The parent resource under which this resource will be created in. Unsupported for Corpus creation requests.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaCreateRequest(IGeminiCorpusResourceId parentResourceId, bool useBetaApi = true)
        {
            ParentResourceId = parentResourceId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
