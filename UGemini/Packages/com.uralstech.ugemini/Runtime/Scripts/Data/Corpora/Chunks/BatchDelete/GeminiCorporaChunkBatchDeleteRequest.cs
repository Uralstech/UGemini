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
    /// Deletes multiple Chunk resources. There is no response.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GeminiCorporaChunkBatchDeleteRequest : IGeminiPostRequest
    {
        /// <summary>
        /// The request messages specifying the Chunks to delete.
        /// </summary>
        public GeminiCorporaChunkBatchDeleteRequestPart[] Requests;

        /// <summary>
        /// The API version to use.
        /// </summary>
        [JsonIgnore]
        public string ApiVersion;

        /// <summary>
        /// Optional. The parent Document containing the Chunks to delete.
        /// </summary>
        /// <remarks>
        /// If given, the parent field in every <see cref="GeminiCorporaChunkBatchDeleteRequestPart"/> must match this value.
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
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}{parentDocument}/chunks:batchDelete";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaChunkBatchDeleteRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaChunkBatchDeleteRequest(bool useBetaApi = true)
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
