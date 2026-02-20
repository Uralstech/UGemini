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

namespace Uralstech.UGemini.CorporaAPI
{
    /// <summary>
    /// Gets information about a specific Corpora API resource. Response type can be <see cref="GeminiCorpus"/>,
    /// <see cref="Documents.GeminiCorpusDocument"/> or <see cref="Chunks.GeminiCorpusChunk"/>.
    /// </summary>
    /// <remarks>
    /// Only available in the beta API.
    /// </remarks>
    public class GeminiCorporaGetRequest : IGeminiGetRequest
    {
        /// <summary>
        /// The API version to use.
        /// </summary>
        public string ApiVersion;

        /// <summary>
        /// The ID of the resource to get.
        /// </summary>
        public IGeminiCorpusResourceId ResourceId;

        /// <inheritdoc/>
        public GeminiAuthMethod AuthMethod { get; set; } = GeminiAuthMethod.OAuthAccessToken;

        /// <inheritdoc/>
        public string OAuthAccessToken { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string GetEndpointUri(GeminiRequestMetadata metadata)
        {
            return $"{GeminiManager.BaseServiceUri}/{ApiVersion}/{ResourceId.ResourceName}";
        }

        /// <summary>
        /// Creates a new <see cref="GeminiCorporaGetRequest"/>.
        /// </summary>
        /// <remarks>
        /// Only available in the beta API.
        /// </remarks>
        /// <param name="resourceId">The ID of the resource to get.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public GeminiCorporaGetRequest(IGeminiCorpusResourceId resourceId, bool useBetaApi = true)
        {
            ResourceId = resourceId;
            ApiVersion = useBetaApi ? "v1beta" : "v1";
        }
    }
}
