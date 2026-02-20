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
using Uralstech.UGemini.CorporaAPI.Documents;

namespace Uralstech.UGemini.CorporaAPI.Chunks
{
    /// <summary>
    /// Creates multiple new Chunk resources. Response type is <see cref="GeminiCorporaChunkBatchUpdateResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchCreateRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The request messages specifying the Chunks to create. A maximum of 100 Chunks can be created in a batch.
        /// </summary>
        public GeminiCorporaChunkBatchCreateRequestPart[] Requests;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <summary>
        /// Optional. The parent Document in which the Chunks will be created.
        /// </summary>
        /// <remarks>
        /// If given, the parent field in every <see cref="GeminiCorporaChunkBatchCreateRequestPart"/> must match this value.
        /// </remarks>
        [JsonIgnore]
        public GeminiCorpusDocumentId ParentDocumentId = null;

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
            string parentDocument = ParentDocumentId != null ? $"/{ParentDocumentId.ResourceName}" : string.Empty;
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}{parentDocument}/chunks:batchCreate";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaChunkBatchCreateRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaChunkBatchCreateRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
