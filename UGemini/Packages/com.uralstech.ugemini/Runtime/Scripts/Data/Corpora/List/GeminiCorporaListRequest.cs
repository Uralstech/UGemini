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

using Uralstech.UGemini.CorporaAPI.Documents;

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Lists the specified type of Corpora API resource.
    /// Response type can be <see cref="GeminiCorporaListResponse"/>, <see cref="Documents.GeminiCorporaDocumentListResponse"/>
    /// or <see cref="Chunks.GeminiCorporaChunkListResponse"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaListRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// Maximum number of objects to return per page. If unspecified, defaults to 10. Maximum is 20 for Documents/Corpora and 100 for Chunks.
        /// </summary>
        public int MaxResponseObjects = 10;

        /// <summary>
        /// A page token from a previous <see cref="GeminiCorporaListRequest"/> call.
        /// </summary>
        public string PageToken = string.Empty;

        /// <summary>
        /// The resource ID for the parent resource, if any.
        /// </summary>
        /// <remarks>
        /// Example:<br/>
        /// To list Corpora, leave it <see langword="null"/>.<br/>
        /// To list the Documents in a Corpus, this should be a <see cref="GeminiCorpusId"/>.<br/>
        /// To list the Chunks in a Documents, this should be a <see cref="Documents.GeminiCorpusDocumentId"/>.
        /// </remarks>
        public IGeminiCorpusResourceId ParentResourceId = null;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
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

            return string.IsNullOrEmpty(PageToken)
                ? $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{parentResource}{createMethod}?pageSize={MaxResponseObjects}"
                : $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{parentResource}{createMethod}?pageSize={MaxResponseObjects}&pageToken={PageToken}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaListRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaListRequest(bool useBetaApi = true)
        {
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaListRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="parentResourceId">The resource ID for the parent resource, if any. See <see cref="ParentResourceId"/> for more info.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaListRequest(IGeminiCorpusResourceId parentResourceId, bool useBetaApi = true)
        {
            ParentResourceId = parentResourceId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
